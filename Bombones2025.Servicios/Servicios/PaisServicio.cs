﻿using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio = null!;
        public PaisServicio()
        {
            try
            {
                _paisRepositorio = new PaisRepositorio();

            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public void Borrar(int paisId)
        {
            _paisRepositorio.Borrar(paisId);
        }

        public bool Existe(Pais pais)
        {
            return _paisRepositorio.Existe(pais);
        }

        public List<Pais> GetPaises()
        {
            return _paisRepositorio.GetPaises();
        }

        public void Guardar(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                _paisRepositorio.Agregar(pais);

            }
            //else
            //{
            //    _paisRepositorio.Editar(pais);
            //}
        }
    }
}
