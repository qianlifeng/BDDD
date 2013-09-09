angular.module('admin.service', []).
    service("urlService", function () {
        this.getParameter = function (name) {
            return decodeURI((RegExp(name + '=' + '(.+?)(&|$)').exec(location.search) || [, null])[1]);
        };
    });

angular.module('admin.directive', []).
    directive('ngEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.ngEnter);
                    });
                    event.preventDefault();
                }
            });
        };
    }).
    directive('ngVisibility', function () {
        return function (scope, element, attrs) {
            //通过watch，监控element对象的ngVisibility的值
            //这个方法仅仅在ngVisibility发生改变的时候执行
            scope.$watch(attrs.ngVisibility, function (value) {
                if (scope.$eval(attrs.ngVisibility)) {
                    element.css("visibility", "visible");
                }
                else {
                    element.css("visibility", "hidden");
                }
            });
        };
    });

angular.module('admin.filter', []);

angular.module('admin', ['admin.service', 'admin.directive', 'admin.filter']).
  controller('adminLoginController', function ($scope, urlService) {
      $scope.init = function () {
          $scope.loginMsg = "";
      }

      $scope.login = function () {

          if ($.trim($scope.UserName) === "" || $.trim($scope.Password) === "") {
              $scope.loginMsg = "用户名或密码不能为空！";
              return;
          }

          $("#btnAdminLogin").button("loading");
          $.ajax({
              url: "/admin/login",
              type: "POST",
              data: JSON.stringify({ "UserName": $scope.UserName, "Password": $scope.Password }),
              dataType: "json",
              contentType: "application/json; charset=utf-8",
              success: function (response) {
                  if (response.loginPass) {
                      var returnURL = urlService.getParameter("ReturnUrl");
                      if (returnURL && returnURL != "null") {
                          window.location.href = returnURL;
                      } else {
                          window.location.href = "/admin";
                      }
                  }
                  else {
                      $scope.loginMsg = "用户名或密码错误！";
                      $scope.$digest();
                      $("#btnAdminLogin").button("reset");
                  }
              },
              error: function (response) {
                  $scope.loginMsg = "服务器发生错误，请稍后重试！";
                  $("#btnAdminLogin").button("reset");
              }
          });
      }

      $scope.cancel = function () {
          $scope.loginMsg = "";
          $scope.UserName = "";
          $scope.Password = "";
      }
  }).
  controller('adminController', function ($scope, $http) {

      $scope.templates = null;
      $scope.currentTemplate = { name: "", url: "" };

      $scope.init = function () {

          $http.get("/admin/menulist").then(function (result) {
              $scope.menus = result.data;
          });
      }

      $scope.logout = function () {
          $.ajax({
              url: "/admin/logout",
              type: "get",
              dataType: "json",
              contentType: "application/json; charset=utf-8",
              success: function (response) {
                  if (response.logoutPass) {
                      alert("退出成功！");
                      window.location.href = "/admin/login";
                  }
                  else {
                      alert("退出失败！");
                  }
              },
              error: function (response) {
                  alert("服务器发生错误，请稍后重试！");
              }
          });
      }
  }).
  controller("menuController", function ($scope) {

      $scope.selectedMenuId;

      $scope.selectMenu = function (menuId) {
          $scope.selectedMenuId = menuId;
      }

      $scope.isSelected = function (menuId) {
          return $scope.selectedMenuId === menuId;
      }

      $scope.navigate = function (name, url) {
          $scope.currentTemplate.name = name;
          $scope.currentTemplate.url = url;
      }
  }).
  controller("menuManageController", function ($scope, $http) {
      $scope.init = function () {
      }

      $scope.editMenu = function () {
          alert($scope.menuCategory);
      }
  });