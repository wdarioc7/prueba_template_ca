# PRUEBA TECNICA TEMPLATE TEKTON

AUTOR:Dario Campaña Diaz

1. Requisitos

Este challenge debe contener lo siguiente:

1.1. Crear un rest API en .net Core (última versión).

Respuesta: Se crea un proyecto en .Net Core 8

1.2. Documentar la API usando swagger.

Respuesta: Se documenta la API usando swagger

![swagger](https://i.postimg.cc/MG4kSkbX/Captura-de-pantalla-2024-08-31-165753.png)

1.3. Usar patrones (ejemplo: mediator pattern, repository pattern, cqrs, etc).

Respuesta: Se utiliza los patrones de diseño repository, mediator y CQRS con Mediatr paquete de nugget de .net

1.4. Aplicar principios SOLID y Clean Code.

Respuesta: Se aplican los principios SOLID 

Single Responsibility Principle (SRP) - Principio de Responsabilidad Única
Cada clase debe tener una única responsabilidad o razón para cambiar. Esto significa que una clase debe tener un solo propósito o función en el sistema. Un solo controlador de donde se heredan los diferentes metodos. A traves de interfaces.

Open/Closed Principle (OCP) - Principio de Abierto/Cerrado
Las entidades de software (clases, módulos, funciones, etc.) deben estar abiertas para la extensión, pero cerradas para la modificación. Esto significa que puedes extender el comportamiento de una clase sin modificar su código fuente original. Solo se utiliza un metodo, un commando y una query para cada funcionalidad del controlador a traves de injección de dependencia.

Liskov Substitution Principle (LSP) - Principio de Sustitución de Liskov
Los objetos de una clase derivada deben poder reemplazar objetos de la clase base sin alterar el comportamiento del programa. Esto significa que las clases derivadas deben ser sustituibles por sus clases base sin que el código cliente note la diferencia. Cada operación dentro del sistema esta separada por commandos y querys desde una capa de infraestructura.

Interface Segregation Principle (ISP) - Principio de Segregación de Interfaces
Una clase no debería estar obligada a implementar interfaces que no utiliza. Esto significa que es mejor tener varias interfaces específicas que una única interfaz grande y general. Cada interfaz esta orientada a su uso por cada servicio no tiene ninguna operación sin funcionalidad.

Dependency Inversion Principle (DIP) - Principio de Inversión de Dependencias
Las clases de alto nivel no deberían depender de clases de bajo nivel. Ambas deberían depender de abstracciones (interfaces). Además, las abstracciones no deberían depender de los detalles. Los detalles deberían depender de las abstracciones. Se implementa interfaces y una capa de aplicacion e infraestructura que a traves del Core se conectan entre si sin violar el principio.

1.5. Implementar la solución haciendo uso de TDD.

Respuesta: Se implementa pruebas unitarias con Xunit

1.6. Usar buenos patrones para las validaciones del Request, y además,
considerar los HTTP Status Codes en cada petición realizada.

respuesta: se implementa en el program el servicio healthcheack de verificacion

1.7. Estructurar el proyecto en N-capas.

![ARK](https://i.postimg.cc/rsMf6gbK/Captura-de-pantalla-2024-08-31-171232.png)

1.8. Agregar un archivo readme (README.md) en dónde se haga una breve
descripción de los patrones o arquitectura usada en el proyecto. Además,
poner los pasos para levantar el proyecto localmente.También, se puede
agregar alguna información que se considere útil.

Respuesta: se agrega el archivo README

1.9. Subir el proyecto a github de manera pública.

Respuesta: Link para clonar:

https://github.com/wdarioc7/prueba_template_ca.git

2. Enunciado
Actualmente, se tiene la parte web de un sistema de registro de productos y se
desea hacer un servicio API que soporte las siguientes funcionalidades:

2.1. Realizar Insert(POST), Update(PUT) y GetById(GET) de un maestro de
productos.

Json del CURL para probar los servicios

{
    "openapi": "3.0.1",
    "info": {
        "title": "PRUEBA DARIO CAMPAÑA-TEMPLATE",
        "version": "v1"
    },
    "paths": {
        "/api/Product": {
            "post": {
                "tags": [
                    "Product"
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            },
            "get": {
                "tags": [
                    "Product"
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/{ProductId}": {
            "get": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "ProductId",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            },
            "put": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "ProductId",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/ProductEntity"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            },
            "delete": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "productId",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        }
    },
    "components": {
        "schemas": {
            "ProductEntity": {
                "type": "object",
                "properties": {
                    "id": {
                        "type": "integer",
                        "format": "int32"
                    },
                    "name": {
                        "type": "string",
                        "nullable": true
                    },
                    "quantity": {
                        "type": "string",
                        "nullable": true
                    },
                    "buyPrice": {
                        "type": "number",
                        "format": "double",
                        "nullable": true
                    },
                    "salePrice": {
                        "type": "number",
                        "format": "double"
                    },
                    "categorieId": {
                        "type": "integer",
                        "format": "int32"
                    },
                    "mediaId": {
                        "type": "integer",
                        "format": "int32",
                        "nullable": true
                    },
                    "date": {
                        "type": "string",
                        "format": "date-time"
                    },
                    "status": {
                        "type": "integer",
                        "format": "int32"
                    },
                    "stock": {
                        "type": "integer",
                        "format": "int32",
                        "nullable": true
                    },
                    "description": {
                        "type": "string",
                        "nullable": true
                    },
                    "discount": {
                        "type": "integer",
                        "format": "int32",
                        "nullable": true
                    },
                    "total_price": {
                        "type": "integer",
                        "format": "int32",
                        "nullable": true
                    }
                },
                "additionalProperties": false
            }
        }
    }
}

2.2. Loguear el tiempo de respuesta de cada request hecho en un archivo de
texto plano.

Respuesta: los logs quedan guardados en el proyecto en la capa web dentro del directorio cada metodo tiene su propio archivo log.

2.3. Mantener en caché(5 min) un diccionario de estados del producto, cuyos
valores son mostrados en el siguiente cuadro:

Status(key) StatusName(value)
1 Active
0 Inactive

Respuesta: se recoje el diccionario y se guarda por defecto el status uno Activo

Se puede usar Cache estándar, Lazy Cache o cualquier otro tipo de cache
que se crea pertinente.

Respuesta: Utiliza Memcache

2.4. Grabar la información del producto localmente usando cualquier tipo de
persistencia. Los campos mandatorios son: ProductId, Name, Status(0 o 1),
Stock, Description y Price.Es posible agregar campos adicionales si es que
la persona evaluada los considera pertinente.

Respuesta: Solucionado en el metodo Post del controller

2.5. El método GetById debe retornar un producto con los siguientes campos:

Campo Comentario
ProductId
Name
StatusName Este campo se obtiene del caché creado en 2.3 basado

en el “Status”.

Stock
Description
Price

Discount Porcentaje de descuento [0-100] el cual es obtenido de
algún servicio externo basado en el ProductId. Este
servicio puede ser https://mockapi.io/ u otro.

Servicio API creado en mockapi: https://66d1ef6262816af9a4f555e4.mockapi.io/api/techdotnet/Products

FinalPrice Price * (100 - Discount) / 100
... Otros campos definidos por el candidato

Respuesta: Solucionado en el metodo GetByIdAsync en el repository en la capa de infraestructura
