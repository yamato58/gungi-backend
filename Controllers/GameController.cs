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
        private static GameService gameService = new GameService();
        private static SelectPieceService selectPieceService = new SelectPieceService();

        // 初期データ
        [HttpGet("initial-data", Name = "GetGame")]
        public ActionResult<MoveResultModel> Get()
        {
            MoveResultModel result = new MoveResultModel
            {
                Pieces = gameService.allPieces,
                GameResult = 0
            };

            return Ok(result);
        }

        // クリックしたデータ
        [HttpPost("select-data", Name = "PostSelectGame")]
        public ActionResult<SelectPieceModel> Post([FromBody] SelectPieceModel selectedPiece)
        {
            SelectPieceService selectPieceService = new SelectPieceService();
            selectPieceService.AddPieceLocation(gameService.allPieces, selectedPiece);

            return Ok(selectPieceService.MoveableLocation);
        }

        // 移動後のデータ
        [HttpPost("next-data", Name = "PostNextGame")]
        public ActionResult<MoveResultModel> Post([FromBody] MovePieceModel movePiece)
        {
            MovePieceService movePieceService = new MovePieceService();
            GameJudgeService gameJudgeService = new GameJudgeService();

            movePieceService.UpdatePosition(gameService.allPieces, movePiece);

            MoveResultModel result = new MoveResultModel
            {
                Pieces = gameService.allPieces,
                GameResult = gameJudgeService.CalGameJudege(gameService.allPieces)
            };

            return Ok(result);
        }

        // リセットデータ
        [HttpPost("boardreset-data", Name = "PostReset")]
        public ActionResult<MoveResultModel> Post()
        {
            gameService = new GameService();

            MoveResultModel result = new MoveResultModel
            {
                Pieces = gameService.allPieces,
                GameResult = 0
            };

            return Ok(result);
        }

        [HttpPost("cellreset-data", Name = "PostResets")]
        public ActionResult<List<MoveableRangeModel>> Post2()
        {
            selectPieceService = new SelectPieceService();

            return Ok(selectPieceService.MoveableLocation);
        }
    }
}
