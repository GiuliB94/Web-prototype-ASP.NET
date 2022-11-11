using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class CompanyList
    {
        public List<Company> Show()
        {
            List<Company> list = new List<Company>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los clients 
                data.setQuery("Select * from Companies");
                data.executeQuery();

                while (data.Reader.Read())
                {
                    //Se cargan los productos de la base // Se deberian verificar nulls? 
                    Company aux = new Company();
                    aux.id = (int)data.Reader["Id"];
                    aux.cuit = (int)data.Reader["Cuit"];
                    aux.companyName = (string)data.Reader["CompanyName"];
                    aux.streetName = (string)data.Reader["StreetName"];
                    aux.streetNumber = (int)data.Reader["StreetNumber"];
                    aux.postalCode = (int)data.Reader["PostalCode"];
                    aux.city = (string)data.Reader["City"];

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
            {   //se cierra la conección a DB
                data.closeConnection();
            }
        }

        public void Add(Company newCompany)
        {
            //Se abre la conección a DB
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
            {   //Se abre la conección a DB
                datos.closeConnection();
            }
        }

        public void Modify(Company modCompany)
        {
            //Se abre la conección a DB
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
                datos.setQuery("delete from Companies where Id=@id");
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

        public List<Company> Filter(string searchBy, string when, string filter)
        {
            List<Company> list = new List<Company>();
            AccessData data = new AccessData();

            string query = "";

            try
            {
                //A CHEQUEAR...
                string column;
                switch (searchBy)
                {
                    case "CUIT":
                        column = "C.Cuit";
                        break;
                    case "Nombre de la empresa":
                        column = "C.CompanyName";
                        break;
                    case "Ciudad":
                        column = "C.City";
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
                

                data.setQuery(query);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan los articulos de la base
                    Company aux = new Company();
                    aux.id = (int)data.Reader["Id"];
                    aux.cuit = (int)data.Reader["Cuit"];
                    aux.companyName = (string)data.Reader["CompanyName"];
                    aux.streetName = (string)data.Reader["StreetName"];
                    aux.streetNumber = (int)data.Reader["StreetNumber"];
                    aux.postalCode = (int)data.Reader["PostalCode"];
                    aux.city = (string)data.Reader["City"];

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
            {   //se cierra la conección a DB
                data.closeConnection();
            }
        }
    }
}
