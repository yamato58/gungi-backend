using GungiBackend.models;
using GungiBackend.Models;

namespace GungiBackend.Services
{
    public class SelectPieceService
    {
        public List<MoveableRangeModel> MoveableLocation { get; set; } = new List<MoveableRangeModel>();

        // 移動できる範囲の追加
        public void AddPieceLocation(List<Piece> allPieces, SelectPieceModel selectedPiece)
        {
            if (selectedPiece.currentX == -1 && selectedPiece.currentY == -1)
            {
                if (selectedPiece.player)
                {
                    BlackHandPieceRange(allPieces, selectedPiece);
                }
                else
                {
                    WhiteHandPieceRange(allPieces, selectedPiece);
                }
                return;
            }

            // 帥の範囲
            if (selectedPiece.pieceName == "帥")
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、上、右、左、右下、左上、右上、左下
                    (0,1), (0,-1), (1,0), (-1,0), (1,1), (-1,-1), (1,-1), (-1,1)
                };

                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
                //MoveAbleRange(allPieces, directions, selectedPiece, 1);
            }

            // 大の範囲
            if (selectedPiece.pieceName == "大")
            {
                var directions1 = new (int dx, int dy)[]
                {
                    // 下、上、右、左
                    (0,1), (0,-1), (1,0), (-1,0)
                };

                MoveableRange(allPieces, directions1, selectedPiece, 8);

                var directions2 = new (int dx, int dy)[]
                {
                    // 右下、左上、右上、左下
                    (1,1), (-1,-1), (1,-1), (-1,1)
                };

                // ツケ
                TsukeRange(allPieces, directions2, selectedPiece, 1);
            }

            // 中の範囲
            if (selectedPiece.pieceName == "中")
            {
                var directions1 = new (int dx, int dy)[]
                {
                    // 右下、左上、右上、左下
                    (1,1), (-1,-1), (1,-1), (-1,1)
                };
                MoveableRange(allPieces, directions1, selectedPiece, 8);

                var directions2 = new (int dx, int dy)[]
                {
                    // 下、上、右、左
                    (0,1), (0,-1), (1,0), (-1,0)
                };

                // ツケ
                TsukeRange(allPieces, directions2, selectedPiece, 1);
            }

            // 小の範囲
            if (selectedPiece.pieceName == "小" && selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、上、右、左、右上、左上
                    (0,1), (0,-1), (1,0), (-1,0),(1,-1),(-1,-1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }
            else if (selectedPiece.pieceName == "小" && !selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 上、下、右、左、右上、左上
                    (0,-1), (0,1), (-1,0), (1,0),(1,1),(-1,1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }

            // 侍の範囲
            if (selectedPiece.pieceName == "侍" && selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、上、右上、左上
                    (0,-1), (0,1),(-1,-1),(1,-1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }
            else if (selectedPiece.pieceName == "侍" && !selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、上、右上、左上
                    (0,1), (0,-1),(1,1),(-1,1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }

            // 槍の範囲
            if (selectedPiece.pieceName == "槍" && selectedPiece.player)
            {
                var directions1 = new (int dx, int dy)[] { (0, -1) }; // 上

                // ツケ
                TsukeRange(allPieces, directions1, selectedPiece, 2);

                var directions2 = new (int dx, int dy)[]
                {
                    // 下、右上、左上
                    (0,1),(1,-1),(-1,-1)
                };
                // ツケ
                TsukeRange(allPieces, directions2, selectedPiece, 1);
            }
            else if (selectedPiece.pieceName == "槍" && !selectedPiece.player)
            {
                var directions1 = new (int dx, int dy)[] { (0, 1) }; // 上

                // ツケ
                TsukeRange(allPieces, directions1, selectedPiece, 2);

                var directions2 = new (int dx, int dy)[]
                {
                    // 下、右上、左上
                    (0,-1),(-1,1),(1,1)
                };
                // ツケ
                TsukeRange(allPieces, directions2, selectedPiece, 1);
            }

            // 馬の範囲
            if (selectedPiece.pieceName == "馬")
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、上、右、左
                    (0,1), (0,-1), (1,0), (-1,0)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 2);
            }

            // 忍の範囲
            if (selectedPiece.pieceName == "忍")
            {
                var directions = new (int dx, int dy)[]
                {
                    // 右下、左上、右上、左下
                    (1,1), (-1,-1), (1,-1), (-1,1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 2);
            }

            // 砦の範囲
            if (selectedPiece.pieceName == "砦" && selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 右、左、上、右下、左下
                    (1,0),(-1,0),(0,-1),(1,1), (-1,1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }
            else if (selectedPiece.pieceName == "砦" && !selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 右、左、上、右下、左下
                    (-1,0),(1,0),(0,1),(-1,-1), (1,-1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }

            // 兵の範囲
            if (selectedPiece.pieceName == "兵")
            {
                var directions = new (int dx, int dy)[]
                {
                    // 上、下
                    (0,-1),(0,1)
                };
                // ツケ
                TsukeRange(allPieces, directions, selectedPiece, 1);
            }

            // 弓の範囲
            if (selectedPiece.pieceName == "弓" && selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、2上、右上上、左上上
                    (0,1),(0,-2),(1,-2),(-1,-2)
                };
                MoveableRange(allPieces, directions, selectedPiece, 1);

                // 2段
                if (selectedPiece.currentZ == 2)
                {
                    var directions2 = new (int dx, int dy)[]
                    {
                    (0,2),(0,-3),(2,-3),(-2,-3)
                    };
                    MoveableRange(allPieces, directions2, selectedPiece, 1);
                }
            }
            else if (selectedPiece.pieceName == "弓" && !selectedPiece.player)
            {
                var directions = new (int dx, int dy)[]
                {
                    // 下、2上、右上上、左上上
                    (0,-1),(0,2),(-1,2),(1,2)
                };
                MoveableRange(allPieces, directions, selectedPiece, 1);

                // 2段
                if (selectedPiece.currentZ == 2)
                {
                    var directions2 = new (int dx, int dy)[]
                    {
                    (0,-2),(0,3),(-2,3),(2,3)
                    };
                    MoveableRange(allPieces, directions2, selectedPiece, 1);
                }
            }
        }

        // 駒がどこまで移動できるかどうか(1, 2, 3, 無限に応じて)
        private void MoveableRange(List<Piece> allPieces, (int dx, int dy)[] directions, SelectPieceModel selectedPiece, int spaces)
        {
            // 各方向
            foreach (var (dx, dy) in directions)
            {
                // 次のx, y
                int nextX = selectedPiece.currentX + dx;
                int nextY = selectedPiece.currentY + dy;

                int cnt = 0;

                // 範囲内のとき
                while (IsInsideBoard(nextX, nextY) && cnt < spaces)
                {
                    {
                        Piece? foundPiece = null;
                        int yumiFlag = 0;

                        // データ分ループ
                        for (int i = 0; i < allPieces.Count; i++)
                        {
                            Piece piece = allPieces[i];

                            // 弓の時
                            yumiFlag = YumiMoveableRange(allPieces, selectedPiece, piece, nextX, nextY);

                            if (yumiFlag != 0)
                            {
                                break;
                            }

                            if (nextX == piece.currentX && nextY == piece.currentY)
                            {
                                if (foundPiece == null || piece.currentZ > foundPiece.currentZ)
                                {
                                    foundPiece = piece;
                                }
                            }
                        }

                        if (yumiFlag == 1)
                        {
                            yumiFlag = 0;
                            break;
                        }
                        else if (yumiFlag == 2)
                        {
                            yumiFlag = 0;
                            return;
                        }

                        // 一致する駒があるかどうか
                        if (foundPiece == null)
                        {
                            MoveableLocation.Add(new MoveableRangeModel(new int[] { nextX, nextY }));
                        }
                        // 帥ツケなし
                        else if (selectedPiece.pieceName == "帥" && selectedPiece.player == foundPiece.player)
                        {
                            break;
                        }
                        else if (foundPiece.player == selectedPiece.player && (foundPiece.pieceName == "帥" || foundPiece.currentZ == 2))
                        {
                            break;
                        }
                        else if (foundPiece.player != selectedPiece.player && selectedPiece.currentZ < foundPiece.currentZ)
                        {
                            break;
                        }
                        else
                        {
                            MoveableLocation.Add(new MoveableRangeModel(new int[] { nextX, nextY }));
                            break;
                        }

                        // 次のマスに移動
                        nextX += dx;
                        nextY += dy;
                    }
                    cnt++;
                }
            }
        }

        //弓専用
        private int YumiMoveableRange(List<Piece> allPieces, SelectPieceModel selectedPiece, Piece piece, int nextX, int nextY)
        {
            // 2上
            if (selectedPiece.pieceName == "弓" && nextY < selectedPiece.currentY)
            {
                if (selectedPiece.player && nextX == piece.currentX &&
                    nextY + 1 == piece.currentY && piece.currentZ == 2)
                {
                    if (selectedPiece.currentX == piece.currentX && selectedPiece.currentY == piece.currentY + 1)
                    {
                        return 2;
                    }
                    return 1;
                }
            }
            else if (selectedPiece.pieceName == "弓" && nextY > selectedPiece.currentY)
            {
                if (!selectedPiece.player && nextX == piece.currentX &&
                    nextY - 1 == piece.currentY && piece.currentZ == 2)
                {
                    if (selectedPiece.currentX == piece.currentX && selectedPiece.currentY == piece.currentY - 1)
                    {
                        return 2;
                    }
                    return 1;
                }
            }
            return 0;
        }

        public void TsukeRange(List<Piece> allPieces, (int dx, int dy)[] directions, SelectPieceModel selectedPiece, int moveRange)
        {
            // ツケ
            if (selectedPiece.currentZ == 1)
            {
                MoveableRange(allPieces, directions, selectedPiece, moveRange);
            }
            else if (selectedPiece.currentZ == 2)
            {
                MoveableRange(allPieces, directions, selectedPiece, moveRange + 1);
            }
        }

        // 最大の x と最小の x を見つける
        public int HandPieceColorFound(List<Piece> allPieces, SelectPieceModel selectedPiece)
        {
            int min = 8;
            int max = 0;
            int piece;

            // データ分ループ
            for (int i = 0; i < allPieces.Count; i++)
            {
                if (allPieces[i].currentY != -1 && allPieces[i].currentY != 10)
                {
                    if (selectedPiece.player)
                    {
                        if (allPieces[i].player)
                        {
                            piece = allPieces[i].currentY;
                            min = Math.Min(min, piece);
                        }
                    }
                    else
                    {
                        if (!allPieces[i].player)
                        {
                            piece = allPieces[i].currentY;
                            max = Math.Max(max, piece);
                        }
                    }
                }
            }
            if (selectedPiece.player)
            {
                return min;
            }
            return max;
        }

        // 持ち駒の場合
        public void BlackHandPieceRange(List<Piece> allPieces, SelectPieceModel selectedPiece)
        {
            for (int y = HandPieceColorFound(allPieces, selectedPiece); y < 9; y++)
            {
                ShareHandRange(y, allPieces, selectedPiece);
            }
        }
        public void WhiteHandPieceRange(List<Piece> allPieces, SelectPieceModel selectedPiece)
        {
            for (int y = HandPieceColorFound(allPieces, selectedPiece); y >= 0; y--)
            {
                ShareHandRange(y, allPieces, selectedPiece);
            }
        }

        // 黒と白で共通の範囲を求める
        private void ShareHandRange(int y, List<Piece> allPieces, SelectPieceModel selectedPiece)
        {
            for (int x = 0; x < 9; x++)
            {
                Piece? topPiece = null;

                // データ分ループ
                foreach (Piece piece in allPieces)
                {
                    if (piece.currentX == x && piece.currentY == y)
                    {
                        if (topPiece == null || piece.currentZ > topPiece.currentZ)
                        {
                            topPiece = piece;
                        }
                    }
                }

                if (topPiece == null)
                {
                    MoveableLocation.Add(new MoveableRangeModel(new int[] { x, y }));
                }
                else if (topPiece.player == selectedPiece.player && topPiece.currentZ < 2 && topPiece.pieceName != "帥")
                {
                    MoveableLocation.Add(new MoveableRangeModel(new int[] { topPiece.currentX, topPiece.currentY }));
                }
            }
        }

        // 盤面にあるかどうか
        private bool IsInsideBoard(int x, int y)
        {
            return x >= 0 && x < 9   // 横が0〜8
                && y >= 0 && y < 9;  // 縦が0〜8
        }
    }
}