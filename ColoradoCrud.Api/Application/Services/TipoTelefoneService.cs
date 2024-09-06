using AutoMapper;
using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Application.Interfaces;
using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;

namespace ColoradoCrud.Api.Application.Services
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly IMapper _mapper;
        public TipoTelefoneService(ITipoTelefoneRepository tipoTelefoneRepository, IMapper mapper)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoTelefoneDto>> GetAllTiposTelefoneAsync()
        {
            return _mapper.Map<IEnumerable<TipoTelefoneDto>>(await _tipoTelefoneRepository.GetAllTiposTelefoneAsync());
        }

        public async Task<TipoTelefoneDto> GetTipoTelefoneByIdAsync(int id)
        {
            return _mapper.Map<TipoTelefoneDto>(await _tipoTelefoneRepository.GetTipoTelefoneByIdAsync(id));
        }

        public async Task AddTipoTelefoneAsync(TipoTelefoneDto dto)
        {
            var tipoTelefone = _mapper.Map<TipoTelefone>(dto);
            await _tipoTelefoneRepository.AddTipoTelefoneAsync(tipoTelefone);
        }

        public async Task UpdateTipoTelefoneAsync(TipoTelefoneDto dto)
        {
            var tipoTelefone = _mapper.Map<TipoTelefone>(dto);
            await _tipoTelefoneRepository.UpdateTipoTelefoneAsync(tipoTelefone);
        }

        public async Task DeleteTipoTelefoneAsync(int id)
        {
            await _tipoTelefoneRepository.DeleteTipoTelefoneAsync(id);
        }

    }

}
