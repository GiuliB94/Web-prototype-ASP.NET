using System;
using System.Collections.Generic;
using MySqlConnector;
using Domain;

namespace Data
{
    public class ProductList
    {
        public List<Product> Show()
        {
            List<Product> list = new List<Product>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los productos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select * from Products");
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
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados 
                datos.setQuery("");
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

        public void Modify(Product modProduct)
        {
            //Se abre la conexión a DB
            AccessData datos = new AccessData();

            try
            {   //Se inserta en DB los datos cargados en la plantilla "modificar"
                datos.setQuery("");
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

        public List<Product> Filter(string searchBy, string when, string filter)
        {
            List<Product> list = new List<Product>();
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

