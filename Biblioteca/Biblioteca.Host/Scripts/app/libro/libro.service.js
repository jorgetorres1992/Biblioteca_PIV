app.service('libroService', 
    [
            '$http', 
            'miConfiguracion',
            function ($http, miConfiguracion) {

                function obtenerLibros() { // esta funcion obtendra los libro del bd
                    return $http.get(miConfiguracion.urlBackend + 'Api/Libro'); 
                }
                function agregarLibro(nuevaLibro) { // agregar
                    return $http.post(miConfiguracion.urlBackend + 'Api/Libro', nuevaLibro);
                }
                function editarLibro(libro) { // editar
                    return $http.put(miConfiguracion.urlBackend + 'Api/Libro/' + libro.Id, libro);

                }
                function eliminarLibro(libro) { // eliminar
                    return $http.delete(miConfiguracion.urlBackend + 'Api/Libro/' + libro.Id);
                }

                function agregarEditorial(libro, editorial) {
                    return $http.put(miConfiguracion.urlBackend + 'Api/Libro/' +
                        libro.Id + '/editorial/' + editorial.Id);
                }

                return {
                    agregarEditorial: agregarEditorial,
                    obtenerLibros: obtenerLibros,
                    agregarLibro: agregarLibro,
                    editarLibro: editarLibro,
                    eliminarLibro: eliminarLibro
                }
            }
    ]
);