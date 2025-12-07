console.log("123");
app.controller('MainCtrl', ["$scope", "$rootScope", "$timeout", function ($scope, $rootScope, $timeout) {
    $rootScope.$mc = {
        isLoading: false


    };

    $scope.uiModel = {
        typeTexts: ""


    };

    $timeout(function () {
        $rootScope.$mc.isLoading = false;
        console.log("123");
    },500) 

    var sound = document.getElementById('hover-sound');

    var generalTheme = document.getElementById("generalTheme");

    $scope.changeText = function (type) {
        console.log("type", type);

        $scope.uiModel.typeTexts = "        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magni, animi dignissimos molestiae, veniam architecto magnam natus commodi officiis expedita alias asperiores quod nam ratione tenetur quia accusantium repudiandae. Repudiandae sint ea perferendis modi, voluptas culpa accusamus dolorem officiis voluptatibus quam dolore sit. Fuga, magnam velit. Libero maxime assumenda laborum a dolores eos, tempore labore voluptates temporibus ducimus earum sunt ipsa, asperiores velit accusamus. Quidem architecto autem vel facilis deserunt, veritatis commodi amet? Maiores corrupti, dolor nam nulla sapiente dolores necessitatibus perspiciatis nihil modi, quas voluptate ipsum dicta, autem inventore. Doloribus, laboriosam illum veniam magni ipsa officiis. Magnam incidunt sed nulla!";

    }

    $scope.changeText('exp');
    generalTheme.play();

    console.log("sound", sound);
    sound.currentTime = 0;

    sound.currentTime = 1;
    sound.currentTime = 0;

    sound.play();
    //const element = document.querySelector(".hover-sound-item");
    //const hoverEvent = new Event("mouseenter");
    //element.dispatchEvent(hoverEvent);
    //const hoverEvent1 = new Event("mouseleave");
    //element.dispatchEvent(hoverEvent1);

    //$timeout(function () {
    //    $(".hover-sound-item")[0].click();
    //},200)
    document.querySelectorAll('.hover-sound-item').forEach(function (item) {
        item.addEventListener('mouseenter', function () {
            sound.play();
        });

        item.addEventListener('mouseleave', function () {
            sound.pause();
            sound.currentTime = 0; 
        });
    });

    $scope.wait = function (duration = 0, sitObj = {}) {
        $rootScope.$mc.isLoading = true;

        $timeout(function () {
            $rootScope.$mc.isLoading = false;

            if (sitObj.type != undefined) {
                switch (sitObj.type) {

                    default:
                }

            }
        }, duration)
    }
   


}])

app.controller('AdminCtrl', ["$scope", "$rootScope", "$timeout", "$http", function ($scope, $rootScope, $timeout, $http) {
    console.log("admin")

    $scope.isLoading = false;


    $scope.model = {
        password: null,
        email:null
    }


   

  
    //const element = document.querySelector(".hover-sound-item");
    //const hoverEvent = new Event("mouseenter");
    //element.dispatchEvent(hoverEvent);
    //const hoverEvent1 = new Event("mouseleave");
    //element.dispatchEvent(hoverEvent1);

  



    $scope.login = function (event = null) {
        console.log("event", event);
        if (event)
            event.stopPropagation();


        $http.post(homeUrl + `/Admin/Login`, $scope.model).then(function (resp) {
            console.log("resp.data",resp.data);
        })

        console.log("login fnc");
    }



}])