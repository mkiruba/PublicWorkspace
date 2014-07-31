userRegistrationModule.factory('getUsersRepository', function ($http, $q) {
    return{
        getUsers : function (users) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/UserRegistration/', data: users
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
}
});

userRegistrationModule.factory('addUserRepository', function ($http, $q) {
    return{
        addUser : function (newUser) {
            var deferred = $q.defer();
            $http({
                method: 'post',
                url: '/api/UserRegistration/', data: newUser
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }  
}
});

userRegistrationModule.factory('deleteUserRepository', function ($http, $q) {
    return {
        deleteUser: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'DELETE',
                url: '/api/UserRegistration/',
                params: {id: id}
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    }
});