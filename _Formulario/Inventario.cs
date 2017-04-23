using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Formulario
{
    class Inventario
    {
        private Producto inicio;

        //almacena el indice que tienen los productos (numero de productos)
        private int _indiceProducto;
        
        /// <summary>
        /// Coonstructor que inicializa el arreglo y el indice
        /// </summary>
        public Inventario()
        {
            _indiceProducto = 0;
        }

        public override string ToString()
        {
            return "Total de productos: " + _indiceProducto;
        }

        /// <summary>
        /// agregar un producto tiene un parametro un objeto de tipo producto
        /// </summary>
        /// <param name="producto"></param>
        public void agregarProducto(Producto producto)
        {
          if (inicio == null)
            {
                inicio = producto;
            }
          else
            {
                Producto temporal = inicio;

                while (temporal.siguiente !=  null)
                {
                    temporal = temporal.siguiente;
                }

                temporal.siguiente = producto;
            }
            _indiceProducto++;
        }

        public Producto buscar(string nombre)
        {
            Producto temporal = inicio;

            while (temporal != null)
            {
                if(temporal.nombre == nombre)
                {
                    return temporal;
                }

                else
                {
                    temporal = temporal.siguiente;
                }
            }
            return null;
        }

        public void eliminar(string nombre)
        {
            if(inicio.nombre == nombre)
            {
                inicio = inicio.siguiente; //aqui se elimina el primero
                _indiceProducto--;
            }

            else
            {
                Producto temporal = inicio;

                while( temporal != null)
                {
                    if(temporal.siguiente.nombre == nombre) //aqui lo encuentra y lo elimina por nombre
                    {
                        temporal.siguiente = temporal.siguiente.siguiente;//aqui lo reemplaza
                        break;
                    }
                    else
                    {
                        temporal = temporal.siguiente; //si no lo encuente sigue iterand 2,3,4...
                    }
                }
                _indiceProducto--;
            }
        }

        public void insertar(Producto producto, int posicion)
        {   
            if(inicio != null && posicion > 0 && posicion <= _indiceProducto)
            {
                Producto temporal = inicio;
                int index = 1;
                while (true)
                {
                    if (index <= posicion)
                    {
                        producto.siguiente = temporal.siguiente;
                        temporal.siguiente = producto;
                        break;
                    }
                    else
                    {
                        index++;
                        temporal = temporal.siguiente;
                    }
                }
                _indiceProducto++;
            }
        }

        public string reporte()
        {
            string mostrar = ToString() + Environment.NewLine;
            Producto temporal = inicio;

            while( temporal != null)
            {
                mostrar += "--------------------------------" + Environment.NewLine;
                mostrar += temporal.ToString();
                temporal = temporal.siguiente;
            }

            return mostrar;
        }
    }
}
