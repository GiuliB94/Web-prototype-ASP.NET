using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;

namespace Business
{
    public class OrderDetailsBusiness
    {
        public List<OrderDetails> Show()
        {
            List<OrderDetails> list = new List<OrderDetails>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los los pedidos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select OD.ID, OD.IdCompany, C.Name, OD.TotalAmount, OD.OrderDate, OD.DeliveryDate, OD.StatusUpdateDate, OD.Status, OD.TotalCost from OrderDetails OD\r\ninner join Companies C\r\nwhere C.ID = OD.IdCompany;");
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    OrderDetails aux = new OrderDetails();
                    aux.ID = Convert.ToInt16(data.Reader["ID"]);
                    aux.OrderDate = Convert.ToDateTime(data.Reader["OrderDate"]);
                    aux.DeliveryDate = Convert.ToDateTime(data.Reader["DeliveryDate"]);
                    aux.IdCompany = Convert.ToInt16(data.Reader["IdCompany"]);
                    aux.CompanyName = data.Reader["Name"].ToString();
                    aux.TotalAmount = Convert.ToDecimal(data.Reader["TotalAmount"]);
                    aux.TotalCost = Convert.ToDecimal(data.Reader["TotalCost"]);
                    aux.Status = (int)data.Reader["Status"];

                    switch (aux.Status)
                    {
                        case 0: aux.StatusDescription = "En espera de aprobación";
                            break;
                        case 1: aux.StatusDescription = "Aprobado";
                            break;
                        case 2: aux.StatusDescription = "En proceso de fabricación";
                            break;
                        case 3: aux.StatusDescription = "Listo para entrega";
                            break;
                        case 4: aux.StatusDescription = "Entregado";
                            break;
                        case 5: aux.StatusDescription = "Rechazado";
                            break;
                    }

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

        public int GetLastId()
        {
            AccessData data = new AccessData();
            int id = 0;
            try
            {
                
                data.setQuery("SELECT ID FROM OrderDetails ORDER by ID DESC LIMIT 1;");
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    OrderDetails aux = new OrderDetails();
                    id = Convert.ToInt16(data.Reader["ID"]);
                }

                //devuelvo listado de productos
                return id;
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

        public OrderDetails GetOrder(int ID)
        {
            AccessData data = new AccessData();
            OrderDetails aux = new OrderDetails();
            try
            {
                //Se setea la query para traer los los pedidos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select * from OrderDetails where ID = " + ID + ";");
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 

                    aux.ID = Convert.ToInt16(data.Reader["ID"]);
                    aux.OrderDate = Convert.ToDateTime(data.Reader["OrderDate"]);
                    aux.DeliveryDate = Convert.ToDateTime(data.Reader["DeliveryDate"]);
                    aux.DeliveryDate = Convert.ToDateTime(data.Reader["StatusUpdateDate"]);
                    aux.IdCompany = Convert.ToInt16(data.Reader["IdCompany"]);
                    aux.TotalAmount = Convert.ToDecimal(data.Reader["TotalAmount"]);
                    aux.Status = (int)data.Reader["Status"];
                    //Se agrega el registro leído a la lista de productos
                }

                //devuelvo listado de productos
                return aux;
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

        public void Add(OrderDetails newOrder)
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();
            try
            {
                data.setQuery($"Insert Into OrderDetails(IdCompany, TotalAmount, OrderDate, DeliveryDate, StatusUpdateDate, Status) Values ({newOrder.IdCompany}, {newOrder.TotalAmount}, '{newOrder.OrderDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}', '{newOrder.DeliveryDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}','{newOrder.StatusUpdateDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}', '{newOrder.Status}');");
                data.executeQuery();
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

        public void UpdateStatus(int IdOrder, int Status)
        {   //Se abre la conexión a DB
            AccessData data = new AccessData();
            try
            {
                data.SetParameter("@ID", IdOrder); 
                data.SetParameter("@Status", Status); 
                data.SetParameter("@StatusUpdateDate", DateTime.Today); 
                data.setQuery("update OrderDetails set StatusUpdateDate=@StatusUpdateDate, Status=@Status WHERE ID = @ID;");
                data.executeQuery();
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
        public void Modify(OrderDetails modOrder) // Ver que datos podrian modificarse 
        {
            //Se abre la conexión a DB
            AccessData data = new AccessData();

            try
            {   //Se inserta en DB los datos cargados en la plantilla "modificar"
                data.SetParameter("@ID", modOrder.ID); //No deberia poder cambiar de cliente la orden
                data.SetParameter("@TotalAmount", modOrder.TotalAmount);
                data.SetParameter("@DeliveryDate", modOrder.DeliveryDate);
                data.SetParameter("@StatusUpdateDate", modOrder.StatusUpdateDate);
                data.SetParameter("@Status", modOrder.Status);
                data.setQuery("update OrderDetails set TotalAmount=@TotalAmount, DeliveryDate=@DeliveryDate, StatusUpdateDate=@StatusUpdateDate, Status=@Status where ID = @ID;");
                data.executeQuery();
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

        //TODO: FILTROS DE ORDENES.
        /*public List<OrderDetails> Filter(string searchBy, string when, string filter)
        {
            List<OrderDetails> list = new List<OrderDetails>();
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
                    OrderDetails aux = new OrderDetails();
                    aux.id = (int)data.Reader["Id"];
                    aux.orderDate = (DateTime)data.Reader["OrderDate"];
                    aux.deliveryDate = (DateTime)data.Reader["DeliveryDate"];
                    aux.idClient = (int)data.Reader["IdClient"];
                    aux.amount = (int)data.Reader["Amount"];
                    aux.status = (string)data.Reader["Status"];

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
        }*/
    }
}

