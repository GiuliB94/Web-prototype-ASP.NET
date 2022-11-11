using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class MaterialList
    {
        public List<Material> Show()
        {
            List<Material> list = new List<Material>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los Materials
                data.setQuery("Select * from Materials");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Material aux = new Material();
                    aux.id = (int)data.Reader["Id"];
                    aux.name = (string)data.Reader["Name"];
                    aux.amount = (int)data.Reader["Amount"];
                    aux.cost = (int)data.Reader["Cost"];

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

        public void Add(Material newMaterial)
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

        public void Modify(Material modMaterial)
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
                datos.setQuery("delete from Material where Id=@id");
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

        public List<Material> Filter(string searchBy, string when, string filter)
        {
            List<Material> list = new List<Material>();
            AccessData data = new AccessData();

            string query = "";

            try
            {
                //A CHEQUEAR...
                string column;
                if (searchBy == "Amount" || searchBy == "Cost")
                {
                    column = searchBy == "Amount" ? "M.Amount" : "M.Cost";
                    switch (when)
                    {
                        case "Mayor a":
                            query += column + " > " + filter;
                            break;
                        case "Menor a":
                            query += column + " < " + filter;
                            break;
                        case "Igual a":
                            query += column + " = " + filter;
                            break;
                    }
                }
                else
                {
                    column = "M.Name";
                    switch (when)
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
                    Material aux = new Material();
                    aux.id = (int)data.Reader["Id"];
                    aux.name = (string)data.Reader["Name"];
                    aux.amount = (int)data.Reader["Amount"];
                    aux.cost = (int)data.Reader["Cost"];

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
