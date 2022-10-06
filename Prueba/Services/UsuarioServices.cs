using Login.Dtos;
using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Services
{
    public class UsuarioServices: IUsuarioServices
    {
        ConectionModels _context;

        public UsuarioServices(ConectionModels context)
        {
            _context = context;
        }
        //Login
        public async Task<RespuestaDTO> LoginSession(LoginDTO uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            { 
                var usuarioAc = await _context.usuarioInfo.FirstOrDefaultAsync(x => x.correo == uss.correo && x.clave == uss.clave && x.vigente == true);
                if (usuarioAc != null)
                {
                    respuestaVi.mensaje = "Se inicio sesion exitosamente";
                    return respuestaVi;
                }
                else
                {
                    respuestaVi.mensaje = "No se encontro el usuario";
                    return respuestaVi;
                }
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
        //registro
        public async Task<RespuestaDTO> Save(UsuarioInfo uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                var usuarioAc = await _context.usuarioInfo.FirstOrDefaultAsync(x => x.correo == uss.correo);
                if (usuarioAc == null)
                {
                    uss.vigente = true;
                    uss.fechaCreacion = DateTime.Now;
                    _context.usuarioInfo.Add(uss);
                    await _context.SaveChangesAsync();
                    respuestaVi.mensaje = "Se creo el usuario correctamente";
                }
                else
                {
                    respuestaVi.mensaje = "Correo en uso";
                }
                return respuestaVi;
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
    }
    public interface IUsuarioServices
    {
        Task<RespuestaDTO> LoginSession(LoginDTO uss);
        Task<RespuestaDTO> Save(UsuarioInfo uss);
    }
}
