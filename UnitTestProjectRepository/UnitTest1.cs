using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionActivos.Repository;
using GestionActivos.Domain;

namespace UnitTestProjectRepository
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTipoActivos()
        {
            //Arrange
            Repository<TipoActivo> tipoActivo = new TipoActivoRepository();
            //Act
            var result = tipoActivo.List;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddTipoActivo()
        {
            //Arrange
            Repository<TipoActivo> tipoActivo = new TipoActivoRepository();
            TipoActivo newTipoActivo = new TipoActivo();
            newTipoActivo.Nombre = "Bienes Inmuebles";
            newTipoActivo.Descripcion = "Bienes Inmuebles";
            //Act
            tipoActivo.Add(newTipoActivo);
            //Assert

        }



    }
}
