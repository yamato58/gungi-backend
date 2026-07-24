using GungiBackend.models;
using GungiBackend.Models;
using GungiBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GungiBackend.Controllers
{
    // クラスをWeb API専用として定義
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // 初期データ
        [HttpGet("initial-data", Name = "GetGame")]
        public ActionResult<MoveResultModel> InitialGet()
        {
            return Ok(_gameService.InitialPosition());
        }

        // クリックしたデータ
        [HttpPost("select-data", Name = "PostSelectGame")]
        public ActionResult<SelectPieceModel> ClickData([FromBody] SelectPieceModel selectedPiece)
        {
            return Ok(_gameService.GetMoveableLocation(selectedPiece));
        }

        // 移動後のデータ
        [HttpPost("next-data", Name = "PostNextGame")]
        public ActionResult<MoveResultModel> MovedData([FromBody] MovePieceModel movePiece)
        {
            return Ok(_gameService.MovePiece(movePiece));
        }

        // リセットデータ
        [HttpPost("boardreset-data", Name = "PostReset")]
        public ActionResult<MoveResultModel> BoardReset()
        {
            _gameService.PositionReset();
            _gameService.AllPiecesListReset();
            _gameService.TurnReset();

            return Ok(_gameService.InitialPosition());
        }

        [HttpPost("cellreset-data", Name = "PostResets")]
        public ActionResult<List<MoveableRangeModel>> CellReset()
        {
            _gameService.CellReset();
            return Ok();
        }

        // リプレイデータ
        [HttpPost("replay-data", Name = "PostReplay")]
        public ActionResult<MoveResultModel> Replay([FromBody] int replayNum)
        {
            return Ok(_gameService.ReplayData(replayNum));
        }
    }
}
