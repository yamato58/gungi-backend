using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public class MovePieceService : IMovePieceService
    {
        // 駒の移動後の計算
        public void UpdatePosition(List<Piece> allPieces, MovePieceModel movePiece)
        {
            int flag = 0;
            int tsuekeCnt = 0;

            for (int i = 0; i < allPieces.Count; i++)
            {
                Piece piece = allPieces[i];

                if (movePiece.Id != piece.Id && piece.CurrentX == movePiece.NextX && piece.CurrentY == movePiece.NextY)
                {
                    if (movePiece.IsPlayer == piece.Player)
                    {
                        tsuekeCnt++;
                        flag = 1;
                    }
                    else if (movePiece.IsPlayer != piece.Player)
                    {
                        if (movePiece.IsGet)
                        {
                            piece.CurrentX = 10;
                            piece.CurrentY = 10;
                            piece.CurrentZ = 1;
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
                if (movePiece.Id == piece.Id && flag == 2)
                {
                    Cal(piece, movePiece);
                    if (tsuekeCnt == 0)
                    {
                        piece.CurrentZ = 1;
                        break;
                    }
                    piece.CurrentZ = tsuekeCnt + 1;
                    break;
                }
                // ツケの場合
                if (movePiece.Id == piece.Id && flag == 1)
                {
                    Cal(piece, movePiece);
                    piece.CurrentZ = 0;
                    piece.CurrentZ = tsuekeCnt + 1;
                    break;
                }
                // 普通の移動の場合
                else if (movePiece.Id == piece.Id && flag == 0)
                {
                    Cal(piece, movePiece);
                    piece.CurrentZ = 1;
                    break;
                }
            }
        }

        // 現在の駒の座標を次の座標に変更
        private static void Cal(Piece piece, MovePieceModel movePiece)
        {
            piece.CurrentX = movePiece.NextX;
            piece.CurrentY = movePiece.NextY;
        }
    }
}
