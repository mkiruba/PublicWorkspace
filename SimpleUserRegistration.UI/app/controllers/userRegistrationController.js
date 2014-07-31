
userRegistrationModule.controller('userRegistrationController', function ($scope, getUsersRepository, addUserRepository, deleteUserRepository) {
    
    getUsers();
    function getUsers() {
        var promise = getUsersRepository.getUsers();
        promise.then(function (users) {
            $scope.users = users;
        }, function (reason) {
            alert('Failed: ' + reason);
        }, function (update) {
            alert('Got notification: ' + update);
        });
    };

    $scope.addUser = function addUser() {        
        var promise = addUserRepository.addUser($scope.newUser);
        promise.then(function () {
            getUsers();
            $scope.userForm.$setPristine();
            $scope.newUser = null;
        }, function (reason) {
            alert('Failed: ' + reason);
        }, function (update) {
            alert('Got notification: ' + update);
        });

    };

    $scope.deleteUser = function deleteUser(user) {
        var promise = deleteUserRepository.deleteUser(user.Id);
        promise.then(function () {
            getUsers();
            $scope.userForm.$setPristine();            
        }, function (reason) {
            alert('Failed: ' + reason);
        }, function (update) {
            alert('Got notification: ' + update);
        });

    };
    
});
