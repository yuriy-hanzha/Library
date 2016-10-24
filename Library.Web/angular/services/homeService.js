var homeService = function ($http, $q, settings) {

    var factory = {};

    factory.GetBooks = function () {

        var deferred = $q.defer();

        $http.get(settings.serviceBase + 'api/Library')
            .success(function (response) {
            deferred.resolve(response);

        }).error(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };


    factory.AddBook = function (model) {

        var deferredObject = $q.defer();

        $http.post(settings.serviceBase + 'api/Library', model).
            success(function (data) {
                deferredObject.resolve(data);
            }).
            error(function (err) {
                deferredObject.reject(err);
            });
        return deferredObject.promise;
    }

    return factory;
}

homeService.$inject = ["$http", "$q", "settings"];
app.factory('homeService', homeService);