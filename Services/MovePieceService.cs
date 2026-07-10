using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public class MovePieceService
    {
        //private static GameService gameService = new GameService();

        public void UpdatePosition(List<Piece> allPieces, MovePieceModel movePiece)
        {
            int flag = 0;
            int tsuekeCnt = 0;

            for (int i = 0; i < allPieces.Count; i++)
            {
                Piece piece = allPieces[i];

                if (movePiece.id != piece.id && piece.currentX == movePiece.nextX && piece.currentY == movePiece.nextY)
                {
                    if (movePiece.isPlayer == piece.player)
                    {
                        tsuekeCnt++;
                        flag = 1;
                    }
                    else if (movePiece.isPlayer != piece.player)
                    {
                        if (movePiece.isGet)
                        {
                            piece.currentX = 10;
                            piece.currentY = 10;
                            piece.currentZ = 1;
                            flag = 2;
                        }
                        else
                        {
                            tsuekeCnt++;
                            flag = 1;
                        }
                    }
                }
            }
            for (int i = 0; i < allPieces.Count; i++)
            {
                Piece piece = allPieces[i];
                // 取得の場合
                if (movePiece.id == piece.id && flag == 2)
                {
                    Cal(piece, movePiece);
                    if (tsuekeCnt == 0)
                    {
                        piece.currentZ = 1;
                        break;
                    }
                    piece.currentZ = tsuekeCnt + 1;
                    break;
                }
                // ツケの場合
                if (movePiece.id == piece.id && flag == 1)
                {
                    //piece.x = movePiece.nextX;
                    //piece.y = movePiece.nextY;
                    Cal(piece, movePiece);
                    piece.currentZ = 0;
                    piece.currentZ = tsuekeCnt + 1;
                    break;
                }
                // 普通の移動の場合
                else if (movePiece.id == piece.id && flag == 0)
                {
                    Cal(piece, movePiece);
                    piece.currentZ = 1;
                    break;
                }
            }
            tsuekeCnt = 0;
        }
        public void Cal(Piece piece, MovePieceModel movePiece)
        {
            piece.currentX = movePiece.nextX;
            piece.currentY = movePiece.nextY;
        }
    }
}
