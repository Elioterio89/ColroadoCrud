using AutoMapper;
using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Application.Interfaces;
using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;
using System.Collections.Generic;

namespace ColoradoCrud.Api.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
           
            return _mapper.Map<IEnumerable<ClienteDto>>(await _clienteRepository.GetAllClientesAsync()) ;
        }

        public async Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            return _mapper.Map<ClienteDto>(await _clienteRepository.GetClienteByIdAsync(id));
        }

        public async Task AddClienteAsync(ClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(ClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            await _clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }

    }
}
