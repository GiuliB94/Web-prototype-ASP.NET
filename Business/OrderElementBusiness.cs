using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class OrderElementBusiness
    {
        public List<OrderElement> Show(int id)
        {
            List<OrderElement> list = new List<OrderElement>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los los pedidos 
                data.setQuery("Select P.Name, P.Size, P.Color, P.Price, O.Quantity\r\nfrom Products as P, OrderElements as O, OrderHeader as H \r\nwhere P.Id = O.IdProduct and\r\nH.Id = O.IdOrder and \r\nH.Id = " + id);
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    OrderElement aux = new OrderElement();
                    aux.IdOrder = Convert.ToInt16(data.Reader["IdOrder"]);
                    aux.LineItem = Convert.ToInt16(data.Reader["LineItem"]);
                    aux.IdProduct = Convert.ToInt16(data.Reader["IdProduct"]);
                    aux.Quantity = (int)data.Reader["Quantity"];
                    aux.Comment = data.Reader["Comment"].ToString();

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
            AccessData data = new AccessData();

            try
            {
                data.setQuery($"Insert Into OrderElements(LineItem, IdOrder, IdProduct, Quantity, Comment) Values ({newOrderElement.LineItem}, {newOrderElement.IdOrder}, {newOrderElement.IdProduct}, {newOrderElement.Quantity}, '{newOrderElement.Comment}' );");
                //TODO: setear parámetros? - Lucas
                data.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void Modify(OrderElement modOrderElement) //Se deberia poder modificar un pedido? 
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los data cargados en la plantilla "modificar"
                data.setQuery("Select telacreistewexd");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se cierra la conexión a DB
                data.closeConnection();
            }
        }

        public void Delete(int id) //Se deberia poder borrar un pedido? Pa mi que no
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery("delete from  where Id=@Id");
                datos.SetParameter("@Id", id);
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
                    aux.IdOrder = Convert.ToInt16(data.Reader["Id"]);
                    aux.LineItem = Convert.ToInt16(data.Reader["OrderDate"]);
                    aux.IdProduct = Convert.ToInt16(data.Reader["DeliveryDate"]);
                    aux.Quantity = (int)data.Reader["IdClient"];
                    aux.Comment = data.Reader["Comment"].ToString();

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
