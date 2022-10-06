using Microsoft.EntityFrameworkCore;
using Tareas.DTOS;
using Tareas.Models;

namespace Tareas.Services
{
    public class SellerServices: ISellerServices
    {
        ConectionModels _context;

        public SellerServices(ConectionModels context)
        {
            _context = context;
        }

        public IEnumerable<Seller> Get()
        {
            return _context.seller;
        }
        public async Task<RespuestaDTO> Save(Seller uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                uss.vigente = true;
                _context.seller.Add(uss);
                respuestaVi.mensaje = "Se creo la tarea correctamente";
                return respuestaVi;
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
        public async Task<RespuestaDTO> Update(Seller uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                var usuarioAc = _context.seller.Find(uss.code);

                if (usuarioAc != null)
                {
                    usuarioAc = uss;

                    var actu =  await _context.SaveChangesAsync();
                    respuestaVi.mensaje = "Se actualizo la tarea con correctamente";
                    return respuestaVi;
                }
                else
                {
                    respuestaVi.mensaje = "No se encontro la tarea seleccionada";
                    return respuestaVi;
                }
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }

        }
        public async Task<RespuestaDTO> Delete(int uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                var usuarioAc = _context.seller.Find(uss);

                if (usuarioAc != null)
                {

                     _context.seller.Remove(usuarioAc);
                    await _context.SaveChangesAsync();
                    respuestaVi.mensaje = "Se actualizo la tarea con correctamente";
                    return respuestaVi;
                }
                else
                {
                    respuestaVi.mensaje = "No se encontro la tarea seleccionada";
                    return respuestaVi;
                }
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }

        }
    }
    public interface ISellerServices
    {
        IEnumerable<Seller> Get();
        Task<RespuestaDTO> Save(Seller uss);
        Task<RespuestaDTO> Update(Seller uss);
        Task<RespuestaDTO> Delete(int uss);
    }
}
