namespace Monopoly
{
    public partial class Form1 : Form
    {
        public static List<Feld> fields;
        private List<MenschlicherSpieler> players;
        public static Bank? bank;
        public static Random rnd = new Random();
        private Button btn;
        public TextBox tb_PlayerStats;
        static int playersTurn = 0;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.ClientSize = new Size(1000, 1000);
            InitFields();
            InitPlayers();
            bank = new Bank();
            btn = new Button()
            {
                Location = new Point((int)(Height * 0.5), (int)(Width * 0.5)),
                Text = "Würfeln",

            };
            btn.Click += btn_Wuerfel_Click;
            tb_PlayerStats = new TextBox()
            {
                Location = new Point(200, 200),
                Width = 150,
                Height = 100,
                Multiline = true,
                ReadOnly = true,
            };
            Controls.Add(btn);
            Controls.Add(tb_PlayerStats);
        }

        private void btn_Wuerfel_Click(object sender, EventArgs e)
        {
            MenschlicherSpieler currentPlayer = players[playersTurn];
            int[] geworfen = currentPlayer.Wurf();
            tb_PlayerStats.Text = "Spieler: " + currentPlayer.Name + "\r\n"
                + "Geld: " + currentPlayer.Geld + "\r\n" +
                "Anzahl Pasch in Folge: 0 \r\n" +
                "Wurf: " + geworfen[0] + " " + geworfen[1];
            //MessageBox.Show(currentPlayer.Name + " " + geworfen[0] +" " + geworfen[1]);
            //currentPlayer.Position += geworfen[0] + geworfen[1];
            for (int i = 0; i < geworfen[0] + geworfen[1]; i++)
            {
                currentPlayer.Position++;
                if (currentPlayer.Position >= 40)
                    currentPlayer.Position = 0;
                this.Invalidate();
                Thread.Sleep(100);
                Application.DoEvents();
            }
            currentPlayer.Position %= 40;
            if (geworfen[0] != geworfen[1])
            {
                playersTurn++;
                if (playersTurn == players.Count)
                    playersTurn = 0;
            }
            //this.Invalidate();

        }
        private void InitFields()
        {
            fields = new List<Feld>
            {
                new Los { Name = "Los", Type = "corner" },                         // 0 Start
                new Strasse { Name = "Badstrasse", Type = "street", Color = Color.Brown },   // 1
                new Geschehnisse { Name = "Gemeinschaftsfeld", Type = "community" },                      // 2
                new Strasse { Name = "Turmstrasse", Type = "street", Color = Color.Brown },   // 3
                new Steuer { Name = "Einkommenssteuer", Type = "tax" },                            // 4
                new Bahnhof { Name = "Südbahnhof", Type = "railroad" },                       // 5
                new Strasse {Name = "Chausseestrasse",  Type = "street", Color = Color.DeepSkyBlue }, // 6
                new Geschehnisse { Name = "Ereignisfeld", Type = "chance" },                         // 7
                new Strasse { Name = "Elisenstrasse", Type = "street", Color = Color.DeepSkyBlue }, // 8
                new Strasse { Name = "Poststrasse", Type = "street", Color = Color.DeepSkyBlue }, // 9
                new OhneFunktionFeld { Name = "Nur zu Besuch", Type = "corner" },                         // 10 Gefängnis
                new Strasse { Name = "Seestrasse", Type = "street", Color = Color.Pink },     // 11
                new Werk {Name = "Elektrizitätswerk",  Type = "utility" },                        // 12
                new Strasse { Name = "Hafenstrasse", Type = "street", Color = Color.Pink },     // 13
                new Strasse { Name = "Neue Strasse", Type = "street", Color = Color.Pink },     // 14
                new Bahnhof { Name = "Westbahnhof", Type = "railroad" },                       // 15
                new Strasse { Name = "Münchener Strasse", Type = "street", Color = Color.Orange },   // 16
                new Geschehnisse { Name = "Gemeinschaftsfeld", Type = "community" },                      // 17
                new Strasse { Name = "Wiener Strasse", Type = "street", Color = Color.Orange },   // 18
                new Strasse { Name = "Berliner Strasse", Type = "street", Color = Color.Orange },   // 19
                new OhneFunktionFeld { Name = "Frei parken", Type = "corner" },                         // 20 Frei Parken
                new Strasse {Name = "Theaterstrasse",  Type = "street", Color = Color.Red },      // 21
                new Geschehnisse { Name = "Ereignisfeld", Type = "chance" },                         // 22
                new Strasse { Name = "Museumstrasse", Type = "street", Color = Color.Red },      // 23
                new Strasse { Name = "Opernplatz", Type = "street", Color = Color.Red },      // 24
                new Bahnhof { Name = "Nordbahnhof", Type = "railroad" },                       // 25
                new Strasse { Name = "Lessingstrasse", Type = "street", Color = Color.Yellow },   // 26
                new Strasse { Name = "Schillerstrasse", Type = "street", Color = Color.Yellow },   // 27
                new Werk { Name = "Wasserwerk", Type = "utility" },                        // 28
                new Strasse { Name = "Goethestrasse", Type = "street", Color = Color.Yellow },   // 29
                new GeheInsGefaengnis { Name = "Gehe ins Gefängnis", Type = "corner" },                         // 30 Gehe in Gefängnis
                new Strasse { Name = "Rathausplatz", Type = "street", Color = Color.Green },    // 31
                new Strasse { Name = "Hauptstrasse", Type = "street", Color = Color.Green },    // 32
                new Geschehnisse { Name = "Gemeinschaftsfeld", Type = "community" },                      // 33
                new Strasse { Name = "Bahnhofstrasse", Type = "street", Color = Color.Green },    // 34
                new Bahnhof { Name = "Hauptbahnhof", Type = "railroad" },                       // 35
                new Geschehnisse { Name = "Ereignisfeld", Type = "chance" },                         // 36
                new Strasse { Name = "Parkstrasse", Type = "street", Color = Color.DarkBlue }, // 37
                new Steuer { Name = "Zusatzsteuer", Type = "tax" },                            // 38
                new Strasse { Name = "Schlossallee", Type = "street", Color = Color.DarkBlue }  // 39
            };
            for (int i = 0; i < fields.Count; i++)
            {
                fields[i].Number = i;
                fields[i].SetLocation();
                //MessageBox.Show(fields[i].Location[0] + " " + fields[i].Location[1]);
            }
        }

        private void InitPlayers()
        {
            players = new List<MenschlicherSpieler>
            {
                new MenschlicherSpieler("Spieler 1", Color.Red),
                new MenschlicherSpieler("Spieler 2", Color.Blue),
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMonopolyBoard(e.Graphics);
            DrawPlayers(e.Graphics);
        }

        private void DrawMonopolyBoard(Graphics g)
        {
            int boardSize = Math.Min(ClientSize.Width, ClientSize.Height);
            int margin = 20;
            int tileSize = (boardSize - 2 * margin) / 11;

            Pen pen = Pens.Black;
            int index = 0;

            // Untere Seite
            for (int i = 10; i >= 0; i--)
                DrawField(g, margin + i * tileSize, margin + 10 * tileSize, tileSize, tileSize, fields[index++], FieldSide.Bottom);

            // Linke Seite
            for (int i = 9; i >= 1; i--)
                DrawField(g, margin, margin + i * tileSize, tileSize, tileSize, fields[index++], FieldSide.Left);

            // Obere Seite
            for (int i = 0; i <= 10; i++)
                DrawField(g, margin + i * tileSize, margin, tileSize, tileSize, fields[index++], FieldSide.Top);

            // Rechte Seite
            for (int i = 1; i <= 9; i++)
                DrawField(g, margin + 10 * tileSize, margin + i * tileSize, tileSize, tileSize, fields[index++], FieldSide.Right);
        }

        private enum FieldSide { Top, Bottom, Left, Right }

        private void DrawField(Graphics g, int x, int y, int w, int h, Feld field, FieldSide side)
        {
            Pen pen = Pens.Black;
            g.DrawRectangle(pen, x, y, w, h);

            if (field.Type == "street" && field.Color.HasValue)
            {
                using (Brush brush = new SolidBrush(field.Color.Value))
                {
                    // Balken oben oder seitlich je nach Feldseite
                    int barHeight = 10;
                    switch (side)
                    {
                        case FieldSide.Top:
                            g.FillRectangle(brush, x, y, w, barHeight);
                            break;
                        case FieldSide.Bottom:
                            g.FillRectangle(brush, x, y + h - barHeight, w, barHeight);
                            break;
                        case FieldSide.Left:
                            g.FillRectangle(brush, x, y, barHeight, h);
                            break;
                        case FieldSide.Right:
                            g.FillRectangle(brush, x + w - barHeight, y, barHeight, h);
                            break;
                    }
                }
            }
            else if (field.Type == "corner")
            {
                // Optional: andere Farbe oder Symbol (hier: grau schattiert)
                using (Brush b = new SolidBrush(Color.LightGray))
                    g.FillRectangle(b, x, y, w, h);
                g.DrawRectangle(Pens.Black, x, y, w, h);
            }
            // Text zeichnen
            if (!string.IsNullOrEmpty(field.Name))
            {
                using (Font font = new Font("Arial", 7))
                using (Brush textBrush = new SolidBrush(Color.Black))
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    RectangleF textRect = new RectangleF(x + 2, y + 2, w - 4, h - 4);

                    g.DrawString(field.Name, font, textBrush, textRect, format);
                }
            }

        }

        private void DrawPlayers(Graphics g)
        {
            int boardSize = Math.Min(ClientSize.Width, ClientSize.Height);
            int margin = 20;
            int tileSize = (boardSize - 2 * margin) / 11;

            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];
                int pos = player.Position;

                // Koordinaten für das Feld berechnen
                Point fieldPos = GetFieldPosition(pos, tileSize, margin);

                // Spielfigur zeichnen – als kleiner Kreis im Feld
                int size = 12;
                int offsetX = (i % 2) * (size + 2);  // Damit Spieler sich nicht überlappen
                int offsetY = (i / 2) * (size + 2);

                int px = fieldPos.X + tileSize / 2 - size / 2 + offsetX - 6;
                int py = fieldPos.Y + tileSize / 2 - size / 2 + offsetY - 6;

                using (Brush b = new SolidBrush(player.Color))
                {
                    g.FillEllipse(b, px, py, size, size);
                    g.DrawEllipse(Pens.Black, px, py, size, size);
                }
            }
        }
        private Point GetFieldPosition(int index, int tileSize, int margin)
        {
            if (index < 11)
                return new Point(margin + (10 - index) * tileSize, margin + 10 * tileSize);
            else if (index < 20)
                return new Point(margin, margin + (10 - (index - 10)) * tileSize);
            else if (index < 30)
                return new Point(margin + (index - 20) * tileSize, margin);
            else
                return new Point(margin + 10 * tileSize, margin + (index - 30) * tileSize);
        }

    }
}
