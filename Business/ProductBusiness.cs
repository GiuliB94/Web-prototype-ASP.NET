using System;
using System.Collections.Generic;
using MySqlConnector;
using Domain;
using Data;
using System.Data.Common;

namespace Business
{
    public class ProductBusiness
    {
        public List<Product> Show()
        {
            List<Product> list = new List<Product>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los productos //TODO: JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE. - Juli
                data.setQuery("Select * from Products"); //-> Despues cambiar esto por un StoredProcedure
                //string sp = ""; 
                //data.setProcedure(sp);

                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Product aux = new Product();
                    aux.id = Convert.ToInt16(data.Reader["Id"]);
                    aux.name = data.Reader["Name"].ToString();
                    aux.size = (int)data.Reader["Size"];
                    aux.color = data.Reader["Color"].ToString();
                    aux.price = Convert.ToDecimal(data.Reader["Price"]);
                    aux.description = data.Reader["Description"].ToString();

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

        public void Add(Product newProduct)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();
            data.setQuery("");
            try
            {
                data.executeQuery();
                //newProduct.price = decimal.Parse() 
                //newProduct.color =
                //newProduct.description =
                //newProduct.id = 
                //newProduct.name =
                //newProduct.size =

                //Se inserta en DB los datos cargados 
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   //Se abre la conexión a DB
                data.closeConnection();
            }
        }

        public void Modify(Product modProduct)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();


            try
            {   //Se inserta en DB los datos cargados en la plantilla "modificar"
                datos.setQuery("update Products set Color=@color, Name=@name, Description=@description, Size=@size, Price=@price where Id=@id");
                datos.SetParameter("@id", modProduct.id);
                datos.SetParameter("@color", modProduct.color);
                datos.SetParameter("@name", modProduct.name);
                datos.SetParameter("@price", modProduct.price);
                datos.SetParameter("@description", modProduct.description);
                datos.SetParameter("@size", modProduct.size);
                datos.executeAction();
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

        public void Delete(int id)
        {
            AccessData datos = new AccessData();
            try
            {   //Se elimina el registro
                datos.setQuery("delete from Products where id=@id");
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

        public List<Product> Filter(string searchBy, string when, string filter, string state="3")
        {
            List<Product> list = new List<Product>();
            AccessData data = new AccessData();

            string query = "Select * from Products where ";

            try
            {
                //Filtro de precio por separado para controlar números
                if (searchBy == "Precio")
                {
                    switch (when)
                    {
                        case "Mayor o igual que":
                            query += "Price >= " + filter;
                            break;
                        case "Menor o igual que":
                            query += "Price <= " + filter;
                            break;
                        //case "Igual a":
                        //    query += "P.Precio = " + filter;
                        //    break;
                    }
                }

                //filtro simplificado para la busqueda de nombres y/o
                else
                {
                    string column = "";
                    switch (searchBy)
                    {
                        case "Código":
                            column = "Id like '%" + filter + "%'";
                            break;
                        case "Nombre":
                            column = "Name like '%" + filter +"%'";
                            break;
                        case "Color":
                            column = "Color like '%" + filter + "%'";
                            break;
                        case "Talle":
                            column = "Size like '%" + filter + "%'";
                            break;
                    }
                    //switch (searchBy)
                    //{
                    //    case "Igual a":
                    //        query += column + " like '" + filter + "'";
                    //        break;
                    //    case "Contiene":
                    //        query += column + " like '%" + filter + "%'";
                    //        break;
                    //    case "Comienza con":
                    //        query += column + " like '" + filter + "%'";
                    //        break;
                    //    case "Termina con":
                    //        query += column + " like '%" + filter + "'";
                    //        break;
                    //
                    query += column;
                }

                if (state == "Activo")
                {
                    query += " and State= 1";
                }

                else if(state == "Inactivo")
                {
                    query += " and State= 0";
                }

                

                data.setQuery(query);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan los articulos de la base
                    Product aux = new Product();
                    aux.id = (int)data.Reader["Id"];
                    aux.name = (string)data.Reader["Name"];
                    aux.size = (int)data.Reader["Size"];
                    aux.color = (string)data.Reader["Color"];
                    aux.price = (decimal)data.Reader["Price"];
                    aux.description = (string)data.Reader["Description"];

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

