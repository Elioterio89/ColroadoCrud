using AutoMapper;
using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Application.Interfaces;
using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;

namespace ColoradoCrud.Api.Application.Services
{
    public class TelefoneService  : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepository telefoneRepository, IMapper mapper)
        {
            _telefoneRepository = telefoneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TelefoneDto>> GetAllTelefonesAsync()
        {
            return _mapper.Map<IEnumerable<TelefoneDto>>(await _telefoneRepository.GetAllTelefonesAsync());
        }

        public async Task<TelefoneDto> GetTelefoneByIdAsync(string numero)
        {
            var telefone = await _telefoneRepository.GetTelefoneByIdAsync(numero); 
            var telefoneDto = _mapper.Map<TelefoneDto>(telefone);
            telefoneDto.NomeCliente = telefone?.Cliente.NomeFantasia;
            telefoneDto.DescricaoTipoTelefone = telefone.TipoTelefone.DescricaoTipoTelefone;
            return telefoneDto;
        }

        public async Task<bool> GetExiste(string numero)
        {
            var telefone = await _telefoneRepository.GetTelefoneByIdAsync(numero);
            if (telefone == null)
            {
                return false;
            }
           
                return true;
        }

        public async Task AddTelefoneAsync(TelefoneDto dto)
        {
            var telefone = _mapper.Map<Telefone>(dto);
            await _telefoneRepository.AddTelefoneAsync(telefone);
        }

        public async Task UpdateTelefoneAsync(TelefoneDto dto)
        {
            var telefone = _mapper.Map<Telefone>(dto);
            await _telefoneRepository.UpdateTelefoneAsync(telefone);
        }

        public async Task DeleteTelefoneAsync(string numero)
        {

            await _telefoneRepository.DeleteTelefoneAsync(numero);
        }
    }

}
