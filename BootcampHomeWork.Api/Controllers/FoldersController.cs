using AutoMapper;
using BootcampHomework.Entities;
using BootcampHomeWork.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampHomeWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : BaseController
    {
        private readonly IFolderService _folderService;
        private readonly IMapper _mapper;

        public FoldersController(IFolderService folderService, IMapper mapper)
        {
            _folderService = folderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Folder> folders = await _folderService.GetActivesAsync();

            List<FolderListDto> folderListDtos = _mapper.Map<List<FolderListDto>>(folders.ToList());

            return CreateActionResult(CustomResponseDto<List<FolderListDto>>.Success(200, folderListDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            Folder folder = await _folderService.GetByIdAsync(id);

            //Girilen İd ait kayıt olup olmadıgını kontrol ediyoruz.
            if (folder == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(Folder).Name}({id}) Not Found "));


            FolderDto folderDto = _mapper.Map<FolderDto>(folder);

            return CreateActionResult(CustomResponseDto<FolderDto>.Success(200,folderDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]FolderAddDto folderAddDto)
        {
            Folder folder = _mapper.Map<Folder>(folderAddDto);

            await _folderService.InsertAsync(folder);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]FolderUpdateDto folderUpdateDto)
        {
            Folder folder = _mapper.Map<Folder>(folderUpdateDto);

            await _folderService.UpdateAsync(folder);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
          await _folderService.RemoveAsync(id);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
