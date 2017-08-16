using ExamenFinal.MockData;
using Examen.Modelos;
using Examen.UnidadDeTrabajo;
using Examen.WebApi.Controllers;
using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.WebApe.Tests
{
    public class CorporacionControllerTests
    {
        private readonly CorporacionController _controlador;

        public CorporacionControllerTests()
        {
            _controlador = new CorporacionController(UnidadTrabajoMockeada.ObtenerUnidadDeTrabajo());
        }

        [Fact(DisplayName = "[CorporacionController]  Get ListarTodo")]
        public void Listar_Test()
        {
            var resultado = _controlador.ListarTodo() as OkObjectResult;

            resultado.Should().NotBeNull();

            var modelo = resultado.Value as List<Corporation>;

            modelo.Count().Should().BeGreaterThan(0);
        }


        [Fact(DisplayName = "[CorporacionController] Get TraerPorId")]
        public void TraerPorId_Test()
        {
            var resultado = _controlador.TraerPorId(1) as OkObjectResult;

            resultado.Should().NotBeNull();
        }


        [Fact(DisplayName = "[CorporacionController] Get ObtenerCorporacionesPaginadas")]
        public void ListarPaginado_Test()
        {
            var resultado = _controlador.ObtenerCorporacionesPaginadas(1, 10) as OkObjectResult;

            resultado.Should().NotBeNull();

            var respuesta = resultado.Value as List<Corporation>;

            respuesta.Count().Should().BeGreaterThan(0);
        }


        [Fact(DisplayName = "[CorporacionController] Post Insertar")]
        public void Insertar_Test()
        {
            Corporation corporacion = new Corporation
            {
                Corp_Name = "Corporación 4",
                Street = "Jr. ",
                City = "Caxa",
                State_Prov = "aaa",
                Country = "Peru",
                Mail_Code = "aaaa@om.com",
                Phone_No = "635456455",
                Expr_Dt = DateTime.Now.AddYears(1),
                Corp_Code = "01"
            };

            var resultado = _controlador.Insertar(corporacion) as OkObjectResult;

            resultado.Should().NotBeNull();

            int respuesta = (int)resultado.Value;

            respuesta.Should().BeGreaterThan(0);
        }


        [Fact(DisplayName = "[CorporacionController] Put Actualizar")]
        public void Actualizar_Test()
        {
            Corporation corporacion = (_controlador.TraerPorId(1) as OkObjectResult).Value as Corporation;

            corporacion.Street = "Av. Proceres # 130";
            corporacion.City = "Lima";

            var resultado = _controlador.Actualizar(corporacion) as OkObjectResult;

            resultado.Should().NotBeNull();

            resultado.Value.Should().Be(true);
        }


        [Fact(DisplayName = "[CorporacionController] Delete Eliminar")]
        public void Eliminar_Test()
        {
            var resultado = _controlador.Eliminar(3) as OkObjectResult;

            resultado.Should().NotBeNull();

            resultado.Value.Should().Be(true);
        }


        [Fact(DisplayName = "[CorporacionController] Get ObtenerCorporacionesPaginadas")]
        public void Contar_Registros_Test()
        {
            var resultado = _controlador.ContarRegistros() as OkObjectResult;

            resultado.Should().NotBeNull();

            int respuesta = (int)resultado.Value;
            respuesta.Should().BeGreaterOrEqualTo(3);
        }

    }
}
