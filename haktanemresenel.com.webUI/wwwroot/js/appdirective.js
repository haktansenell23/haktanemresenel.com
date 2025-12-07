
app.directive('msDate', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                // optional: hangi formatta modelde tutulsun: "ms" ("/Date(...)/"), "iso", "sql" (yyyyMMddHHmmss)
                // default "ms"
                msDate: '@?'
            },
            link: function (scope, element, attrs, ngModel) {
                var outFormat = scope.msDate || 'ms'; // 'ms'|'iso'|'sql'

                // ---------- Yardımcı fonksiyonlar ----------
                function pad(n, width) {
                    n = String(n);
                    while (n.length < width) n = '0' + n;
                    return n;
                }

                function toYYYYMMDDHHMMSS(date) {
                    // date is a Date object (local time)
                    return '' +
                        date.getFullYear() +
                        pad(date.getMonth() + 1, 2) +
                        pad(date.getDate(), 2) +
                        pad(date.getHours(), 2) +
                        pad(date.getMinutes(), 2) +
                        pad(date.getSeconds(), 2);
                }

                function toISO(date) {
                    return date.toISOString();
                }

                function toMsJson(date) {
                    return '/Date(' + date.getTime() + ')/';
                }

                function parseMsJson(str) {
                    // handles "/Date(1764277200000)/" or "1764277200000"
                    if (!str && str !== 0) return null;
                    if (angular.isNumber(str)) return new Date(+str);
                    if (typeof str === 'string') {
                        var m = str.match(/\/?Date\((\-?\d+)(?:[^\d]*)\)\/?/);
                        if (m) return new Date(parseInt(m[1], 10));
                        // maybe it's ISO
                        var d = new Date(str);
                        if (!isNaN(d.getTime())) return d;
                        // maybe pure millis in string
                        var mm = str.match(/^\d+$/);
                        if (mm) return new Date(parseInt(str, 10));
                    }
                    return null;
                }

                function modelToView(modelValue) {
                    if (modelValue == null || modelValue === '') {
                        ngModel.$setViewValue('');
                        ngModel.$render();
                        return;
                    }

                    var dateObj = parseMsJson(modelValue);
                    if (!dateObj || isNaN(dateObj.getTime())) {
                        // if cannot parse, show empty
                        ngModel.$setViewValue('');
                        ngModel.$render();
                        return;
                    }

                    // input[type=date] expects yyyy-MM-dd (local date)
                    var yyyy = dateObj.getFullYear();
                    var mm = pad(dateObj.getMonth() + 1, 2);
                    var dd = pad(dateObj.getDate(), 2);
                    var viewVal = yyyy + '-' + mm + '-' + dd;

                    ngModel.$setViewValue(viewVal);
                    ngModel.$render();
                }

                function viewToModel(viewValue) {
                    if (!viewValue) {
                        ngModel.$setValidity('msdate', true);
                        return null;
                    }
                    // viewValue is "yyyy-MM-dd"
                    // create Date at local midnight
                    var parts = viewValue.split('-');
                    if (parts.length < 3) {
                        ngModel.$setValidity('msdate', false);
                        return undefined;
                    }
                    var y = parseInt(parts[0], 10);
                    var m = parseInt(parts[1], 10) - 1;
                    var d = parseInt(parts[2], 10);
                    var dt = new Date(y, m, d, 0, 0, 0);

                    if (isNaN(dt.getTime())) {
                        ngModel.$setValidity('msdate', false);
                        return undefined;
                    }

                    ngModel.$setValidity('msdate', true);

                    if (outFormat === 'ms') return toMsJson(dt);
                    if (outFormat === 'iso') return toISO(dt);
                    if (outFormat === 'sql') return toYYYYMMDDHHMMSS(dt);

                    // default fallback: ms json
                    return toMsJson(dt);
                }

                // ---------- Parsers & Formatters (ngModel pipeline) ----------
                // Model -> View
                ngModel.$formatters.push(function (modelValue) {
                    // return value used by ngModel.$viewValue pipeline; we'll also manually render below
                    var dateObj = parseMsJson(modelValue);
                    if (!dateObj) return '';
                    var yyyy = dateObj.getFullYear();
                    var mm = pad(dateObj.getMonth() + 1, 2);
                    var dd = pad(dateObj.getDate(), 2);
                    return yyyy + '-' + mm + '-' + dd;
                });

                // View -> Model
                ngModel.$parsers.push(function (viewValue) {
                    // convert view string to requested model format
                    if (!viewValue) return null;
                    var parts = viewValue.split('-');
                    if (parts.length < 3) {
                        ngModel.$setValidity('msdate', false);
                        return undefined;
                    }
                    var y = parseInt(parts[0], 10);
                    var m = parseInt(parts[1], 10) - 1;
                    var d = parseInt(parts[2], 10);
                    var dt = new Date(y, m, d, 0, 0, 0);
                    if (isNaN(dt.getTime())) {
                        ngModel.$setValidity('msdate', false);
                        return undefined;
                    }
                    ngModel.$setValidity('msdate', true);

                    if (outFormat === 'ms') return toMsJson(dt);
                    if (outFormat === 'iso') return toISO(dt);
                    if (outFormat === 'sql') return toYYYYMMDDHHMMSS(dt);
                    return toMsJson(dt);
                });

                // render initial model value to input (if model already has value)
                // using $render ensures Angular updates the DOM correctly
                ngModel.$render = function () {
                    var viewVal = ngModel.$viewValue || '';
                    element.val(viewVal);
                };

                // watch model (in case it's changed programmatically elsewhere)
                scope.$watch(function () {
                    return ngModel.$modelValue;
                }, function (newVal) {
                    // update the view only if different from current view
                    var dateObj = parseMsJson(newVal);
                    if (!dateObj) {
                        element.val('');
                        return;
                    }
                    var yyyy = dateObj.getFullYear();
                    var mm = pad(dateObj.getMonth() + 1, 2);
                    var dd = pad(dateObj.getDate(), 2);
                    var nv = yyyy + '-' + mm + '-' + dd;
                    if (element.val() !== nv) element.val(nv);
                });

                // keep native change/input events hooked to ngModel
                element.on('change input', function () {
                    scope.$apply(function () {
                        var v = element.val();
                        var modelVal = viewToModel(v);
                        // Only setModelValue if parser produced defined value
                        if (typeof modelVal !== 'undefined') {
                            ngModel.$setViewValue(v);
                            // convert view to actual model representation expected by app:
                            // run through parsers to get the model format expected by controller (we already did viewToModel)
                            // but to keep consistent with Angular pipeline, call $setPristine? not necessary
                            // directly set model:
                            if (outFormat === 'ms') ngModel.$modelValue = toMsJson(new Date(v));
                            else if (outFormat === 'iso') ngModel.$modelValue = toISO(new Date(v));
                            else if (outFormat === 'sql') ngModel.$modelValue = toYYYYMMDDHHMMSS(new Date(v));
                            else ngModel.$modelValue = toMsJson(new Date(v));

                            // notify watchers
                            ngModel.$commitViewValue && ngModel.$commitViewValue();
                            // trigger digest watchers on model
                        }
                    });
                });

                // cleanup
                scope.$on('$destroy', function () {
                    element.off('change input');
                });

            }
        };
    });
