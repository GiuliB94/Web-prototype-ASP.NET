﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderElementList
    {
        public List<OrderElement> Show()
        {
            List<OrderElement> list = new List<OrderElement>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los los pedidos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select * from OrderElements");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    OrderElement aux = new OrderElement();
                    aux.idOrder = Convert.ToInt16(data.Reader["IdOrder"]);
                    aux.lineItem = Convert.ToInt16(data.Reader["LineItem"]);
                    aux.idProduct = Convert.ToInt16(data.Reader["IdProduct"]);
                    aux.quantity = (int)data.Reader["Quantity"];

                    //Se agrega el registro leído a la lista de productos
                    list.Add(aux);

                }

                //devuelvo listado de productos
                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {   //se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public void Add(OrderElement newOrderElement)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados 
                datos.setQuery("bueno si dsp vemos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                datos.closeConnection();
            }
        }

        public void Modify(OrderElement modOrderElement) //Se deberia poder modificar un pedido? 
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados en la plantilla "modificar"
                datos.setQuery("Select telacreistewexd");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se cierra la conexión a DB
                datos.closeConnection();
            }
        }

        public void Delete(int id) //Se deberia poder borrar un pedido? Pa mi que no
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery("delete from  where id=@id");
                datos.SetParameter("@id", id);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                datos.closeConnection();
            }
        }

        public List<OrderElement> Filter(string searchBy, string when, string filter)
        {
            List<OrderElement> list = new List<OrderElement>();
            AccessData data = new AccessData();

            string query = "";

            try
            {
                //A CHEQUEAR...
                if (searchBy == "Precio")
                {
                    switch (when)
                    {
                        case "Mayor a":
                            query += "P.Precio > " + filter;
                            break;
                        case "Menor a":
                            query += "P.Precio < " + filter;
                            break;
                        case "Igual a":
                            query += "P.Precio = " + filter;
                            break;
                    }
                }
                else
                {
                    string column = "";
                    switch (searchBy)
                    {
                        case "Código":
                            column = "P.Id";
                            break;
                        case "Nombre":
                            column = "P.Name";
                            break;
                        case "Color":
                            column = "P.Color";
                            break;
                    }
                    switch (searchBy)
                    {
                        case "Igual a":
                            query += column + " like '" + filter + "'";
                            break;
                        case "Contiene":
                            query += column + " like '%" + filter + "%'";
                            break;
                        case "Comienza con":
                            query += column + " like '" + filter + "%'";
                            break;
                        case "Termina con":
                            query += column + " like '%" + filter + "'";
                            break;
                    }
                }

                data.setQuery(query);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan los articulos de la base
                    OrderElement aux = new OrderElement();
                    aux.idOrder = Convert.ToInt16(data.Reader["Id"]);
                    aux.lineItem = Convert.ToInt16(data.Reader["OrderDate"]);
                    aux.idProduct = Convert.ToInt16(data.Reader["DeliveryDate"]);
                    aux.quantity = (int)data.Reader["IdClient"];

                    //Se agrega el registro leído a la lista de articulos
                    list.Add(aux);

                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //se cierra la conexión a DB
                data.closeConnection();
            }
        }
    }
}
