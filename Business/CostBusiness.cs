using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CostBusiness
    {
        public List<CostXProduct> Show()
        {
            List<CostXProduct> list = new List<CostXProduct>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los los pedidos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select * from CostXProduct;");                
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    CostXProduct aux = new CostXProduct();
                    aux.IdProduct = (int)data.Reader["IdProduct"];
                    aux.Material = (decimal)data.Reader["Material"];
                    aux.Box = (decimal)data.Reader["Box"];
                    aux.Color = (decimal)data.Reader["Color"];
                    aux.Bag = (decimal)data.Reader["Bag"];
                    aux.Handwork = (decimal)data.Reader["Handwork"];
                    aux.TotalCostxProduct = (decimal)data.Reader["TotalCost"];

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

        public List<CostXProduct> GetCostForProduct(int id)
        {
            List<CostXProduct> list = new List<CostXProduct>();
            AccessData data = new AccessData();

            try
            {
                //Se setea la query para traer los los pedidos //JOIN CON?? DETERMINAR QUE DEBERIA MOSTRARSE.
                data.setQuery("Select * from CostXProduct where IdProduct =" + id + ";");
                data.executeQuery();
                while (data.Reader.Read())
                {
                    //Se cargan las lineas de elemento? // Se deberian verificar nulls? 
                    CostXProduct aux = new CostXProduct();
                    aux.IdProduct = (int)data.Reader["IdProduct"];
                    aux.Material = (decimal)data.Reader["Material"];
                    aux.Box = (decimal)data.Reader["Box"];
                    aux.Color = (decimal)data.Reader["Color"];
                    aux.Bag = (decimal)data.Reader["Bag"];
                    aux.Handwork = (decimal)data.Reader["Handwork"];
                    aux.TotalCostxProduct = (decimal)data.Reader["TotalCost"];

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
    }
}
