describe('corporacionController', function(){
    var controller, service;

    beforeEach(function(){
        module('app');
    });

    beforeEach(
        inject(function($controller,_authenticationService_, $q){
            service = _authenticationService_;

            spyOn(service, "list").and.callFake(function(){
                var deferred = $q.defer();
                deferred.resolve('Response');

                return deferred.promise;
            });

            controller = $controller('corporacionController',{
                authenticationService: service
            });
        })
    );

    describe('List Test', function(){
        it('List', inject(function(){
            controller.List();
            expect(controller.showError).toEqual(false);
        }));
    });

});