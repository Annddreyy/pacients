using Newtonsoft.Json;

namespace Пациенты_и_сотрудники
{
    public partial class ПациентыИСотрудники : Form
    {

        private const string apiUrl = "http://10.30.76.66:8082/PersonLocations";
        private const int refreshInterval = 3000;

        private HttpClient httpClient;
        private System.Threading.Timer refreshTimer;

        public ПациентыИСотрудники()
        {
            InitializeComponent();
            pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            pictureBox.MouseClick += new MouseEventHandler(click);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void click(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"X: {e.X}, Y: {e.Y}");
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            RefreshImage();
            try
            {
                // Выполняем GET запрос к API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Проверяем статус код ответа
                if (response.IsSuccessStatusCode)
                {
                    // Читаем содержимое ответа
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Парсим JSON ответ в список объектов Person
                    List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(responseBody);
                }
                else
                {
                    // Обработка ошибок, если необходимо
                    //MessageBox.Show("Ошибка при выполнении запроса: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, если необходимо
                //MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ПациентыИСотрудники_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Random rand = new Random();

            int[] lastSecurityPointNumbers = new int[20];
            string[] personRoles = new string[20];
            string[] lastSecurityPointDirection = new string[20];
            for (int i = 0; i < 20; i++)
            {
                int point = rand.Next(1, 22);
                string role = (rand.Next(0, 2) == 1) ? "Сотрудник" : "Клиент";
                string pointDirection = (rand.Next(0, 2) == 1) ? "in" : "out";

                lastSecurityPointNumbers[i] = point;
                personRoles[i] = role;
                lastSecurityPointDirection[i] = pointDirection;
            }

            for (int i = 0; i < lastSecurityPointDirection.Length; i++)
            {
                Graphics g = e.Graphics;

                Brush brush;
                if (personRoles[i] == "Клиент")
                    brush = new SolidBrush(Color.Green);
                else
                    brush = new SolidBrush(Color.Blue);

                int x, y;

                if (lastSecurityPointDirection[i] == "in")
                {
                    (x, y) = GetCoordinatesIn(lastSecurityPointNumbers[i]);
                }
                else
                {
                    (x, y) = GetCoordinatesOut(lastSecurityPointNumbers[i]);
                }

                g.FillEllipse(brush, x, y, 10, 10);
            }
        }

        private void RefreshImage()
        {
            Graphics graphics = pictureBox.CreateGraphics();

            graphics.Clear(Color.White);

            pictureBox.Refresh();
        }

        (int, int) GetCoordinatesIn(int id)
        {
            Random rand = new Random();
            switch (id)
            {
                case 0:
                    return (rand.Next(420, 550), rand.Next(5, 70));
                case 1:
                    return (rand.Next(550, 630), rand.Next(5, 70));
                case 2:
                    return (rand.Next(635, 670), rand.Next(5, 70));
                case 3:
                    return (rand.Next(680, 710), rand.Next(5, 70));
                case 4:
                    return (rand.Next(720, 760), rand.Next(5, 70));
                case 5:
                    return (rand.Next(785, 830), rand.Next(5, 70));
                case 6:
                    return (rand.Next(865, 900), rand.Next(5, 70));
                case 7:
                    return (rand.Next(5, 60), rand.Next(220, 270));
                case 8:
                    return (rand.Next(80, 170), rand.Next(220, 270));
                case 9:
                    return (rand.Next(190, 350), rand.Next(220, 270));
                case 10:
                    return (rand.Next(370, 390), rand.Next(220, 270));
                case 11:
                    return (rand.Next(410, 520), rand.Next(220, 270));
                case 12:
                    return (rand.Next(550, 580), rand.Next(220, 270));
                case 13:
                    return (rand.Next(590, 630), rand.Next(220, 270));
                case 14:
                    return (rand.Next(650, 680), rand.Next(220, 270));
                case 15:
                    return (rand.Next(700, 830), rand.Next(220, 270));
                case 16:
                    return (rand.Next(850, 900), rand.Next(220, 270));
                case 17:
                    return (rand.Next(5, 30), rand.Next(5, 70));
                case 18:
                    return (rand.Next(50, 70), rand.Next(5, 70));
                case 19:
                    return (rand.Next(90, 150), rand.Next(5, 70));
                case 20:
                    return (rand.Next(170, 190), rand.Next(5, 70));
                case 21:
                    return (rand.Next(210, 300), rand.Next(5, 70));
                case 22:
                    return (rand.Next(340, 360), rand.Next(5, 70));
                default:
                    return (0, 0);
            }
        }

        (int, int) GetCoordinatesOut(int id)
        {
            switch (id)
            {
                case 0:
                    return (535, 120);
                case 1:
                    return (580, 120);
                case 2:
                    return (650, 120);
                case 3:
                    return (695, 120);
                case 4:
                    return (740, 120);
                case 5:
                    return (810, 120);
                case 6:
                    return (890, 120);
                case 7:
                    return (30, 200);
                case 8:
                    return (130, 200);
                case 9:
                    return (270, 200);
                case 10:
                    return (380, 200);
                case 11:
                    return (470, 200);
                case 12:
                    return (565, 200);
                case 13:
                    return (610, 200);
                case 14:
                    return (665, 200);
                case 15:
                    return (760, 200);
                case 16:
                    return (870, 200);
                case 17:
                    return (15, 120);
                case 18:
                    return (60, 120);
                case 19:
                    return (120, 120);
                case 20:
                    return (180, 120);
                case 21:
                    return (260, 120);
                case 22:
                    return (350, 120);
                default:
                    return (0, 0);
            }
        }
    }
    public class Person
    {
        public string PersonCode { get; set; }
        public string PersonRole { get; set; }
        public int LastSecurityPointNumber { get; set; }
        public string LastSecurityPointDirection { get; set; }
        public DateTime LastSecurityPointTime { get; set; }
    }

}
