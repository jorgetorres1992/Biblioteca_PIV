app.controller('editorialController', [
    '$scope',
    function ($scope) {
        $scope.editoriales = [
            {
                id: '1',
                nombre: 'Editorial 1'
            },
            {
                id: '2',
                nombre: 'Editorial 2'
            }


        ];
        $scope.editorialActual = { // se crea un objeto que maneja el editorial
            id: '123',
            nombre: 'Editorial123 '

        };
    }
    ]
);