﻿using Bombones2025.Entidades;

namespace Bombones2025.Datos.Repositorios
{
    public class FrutoSecoRepositorio
    {
        //Atributo privado del repo donde se almacenan los paises
        private List<FrutoSeco> frutosSecos = new();
        private readonly string ruta = null!;
        public FrutoSecoRepositorio(string rutaArchivo)
        {
            ruta=rutaArchivo;
            LeerDatos();
        }
        /// <summary>
        /// Método para enviar la lista de países a otra capa
        /// </summary>
        /// <returns></returns>
        public List<FrutoSeco> GetLista()
        {
            return frutosSecos;
        }
        /// <summary>
        /// Método para leer los países desde el archivo secuencial
        /// </summary>
        /// <param name="ruta">Se pasa el nombre del archivo</param>
        private void LeerDatos()
        {
            if (!File.Exists(ruta))
            {
                return;
            }
            var registros = File.ReadAllLines(ruta);
            foreach (var registro in registros)
            {
                FrutoSeco fruto = ConstruirFruto(registro);
                frutosSecos.Add(fruto);
            }

        }
        /// <summary>
        /// Método privado para obtener un fruto seco
        /// </summary>
        /// <param name="registro">Recibe un string con los datos del país separados por |</param>
        /// <returns>Un pais</returns>
        private FrutoSeco ConstruirFruto(string registro)
        {
            var campos = registro.Split('|');
            var frutoSecoId = int.Parse(campos[0]);
            var descripcion = campos[1];
            return new FrutoSeco()
            {
                Descripcion = descripcion,
                FrutoSecoId = frutoSecoId
            };
        }
    }
}
