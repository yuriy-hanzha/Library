var homeController = function ($scope, homeService) {

    $scope.Books = [];
    $scope.DisplayedBooks = [];

    $scope.Book = {
        Name: '',
        Author: '',
        PublishingYear: null,
        PublishingHouse: null
    };

    $scope.FilterText = '';

    $scope.init = function () {
        homeService.GetBooks()
        .then(function (data) {
            $scope.Books = $scope.DisplayedBooks = data;
        });
    };

    $scope.AddBook = function () {
        homeService.AddBook($scope.Book)
            .then(function (data) {
                $scope.Books.push($scope.Book);
                $scope.DisplayedBooks = $scope.Books;
                ClearBookForm();
            }, function (error) { })
    };

    $scope.$watch('FilterText', function () {
        if (!$scope.FilterText) $scope.DisplayedBooks = $scope.Books;
        var newBookList = [];
        var data = $scope.FilterText.toLowerCase();
        angular.forEach($scope.Books, function (val, key) {
            if (val.Name.toLowerCase().indexOf(data) != -1
                || val.Author.toLowerCase().indexOf(data) != -1) {
                this.push(val);
            };
        }, newBookList);
        $scope.DisplayedBooks = newBookList;
        $scope.apply;
    });

    var ClearBookForm = function () {
        $scope.Book = {
            Name: '',
            Author: '',
            PublishingYear: null,
            PublishingHouse: null
        };
    };

    $scope.MaxYear = new Date().getFullYear();
}

homeController.$inject = ["$scope", "homeService"];
app.controller("homeController", homeController);