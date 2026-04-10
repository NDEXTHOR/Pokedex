using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pokedex {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            this.Icon = new BitmapImage(new Uri(@"C:\Users\bjrf8\source\repos\Pokedex\Pokedex\pokemon.png", UriKind.Absolute));

            txtMensaje.Focus();

            // Mensaje inicial del Bot
            AgregarMensaje("¡Hola Entrenador! Soy tu Pokédex. ¿En qué te puedo ayudar hoy?", false); // El false indica que es un mensaje del bot, no del usuario
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e) {
            String mensajeUsuario = txtMensaje.Text.Trim();

            if (mensajeUsuario == "") {// Para los mensajes vacios
                txtMensaje.Focus();

                // Esta animacion la recicle de Abarrotech V2
                var animacion = new System.Windows.Media.Animation.ThicknessAnimation();
                animacion.Duration = TimeSpan.FromMilliseconds(50);
                animacion.From = new Thickness(0, 0, 15, 0);
                animacion.To = new Thickness(5, 0, 10, 0);
                animacion.AutoReverse = true;
                animacion.RepeatBehavior = new System.Windows.Media.Animation.RepeatBehavior(3);
                txtMensaje.BeginAnimation(MarginProperty, animacion);
            } else { // Para cualquier mensaje que no este vacio
                AgregarMensaje(mensajeUsuario, true);
                txtMensaje.Text = string.Empty;
                txtMensaje.Focus();

                // Por ahora solo simulamos respuestas basicas del bot, pero debo agregar lo de la API
                resouestaBot(mensajeUsuario);
            }
        }

        // Esto esta super mal jaja
        private void resouestaBot(string recibido) {
            var pokemones = new Dictionary<string, string>() {
                { "bulbasaur", "Tipo planta/veneno. Habita en bosques. Tiene un bulbo en la espalda." },
                { "ivysaur", "Tipo planta/veneno. Habita en bosques. Su bulbo crece y florece." },
                { "venusaur", "Tipo planta/veneno. Habita en selvas. Tiene una gran flor en la espalda." },
                { "charmander", "Tipo fuego. Habita en zonas rocosas. Tiene una llama en la cola." },
                { "charmeleon", "Tipo fuego. Habita en montañas. Tiene garras afiladas y llama intensa." },
                { "charizard", "Tipo fuego/volador. Habita en montañas. Tiene alas grandes y escupe fuego." },
                { "squirtle", "Tipo agua. Habita en ríos. Tiene caparazón resistente." },
                { "wartortle", "Tipo agua. Habita en lagos. Tiene cola peluda y caparazón duro." },
                { "blastoise", "Tipo agua. Habita en costas. Tiene cañones de agua en el caparazón." },
                { "caterpie", "Tipo bicho. Habita en bosques. Es una oruga verde pequeña." },
                { "metapod", "Tipo bicho. Habita en árboles. Tiene capullo duro." },
                { "butterfree", "Tipo bicho/volador. Habita en bosques. Tiene alas grandes con patrones." },
                { "weedle", "Tipo bicho/veneno. Habita en bosques. Tiene aguijón en la cabeza." },
                { "kakuna", "Tipo bicho/veneno. Habita en árboles. Tiene capullo rígido." },
                { "beedrill", "Tipo bicho/veneno. Habita en bosques. Tiene aguijones en brazos." },
                { "pidgey", "Tipo normal/volador. Habita en bosques. Es un ave pequeña." },
                { "pidgeotto", "Tipo normal/volador. Habita en bosques. Tiene alas fuertes." },
                { "pidgeot", "Tipo normal/volador. Habita en cielos abiertos. Tiene gran velocidad." },
                { "rattata", "Tipo normal. Habita en ciudades. Tiene dientes afilados." },
                { "raticate", "Tipo normal. Habita en ciudades. Tiene incisivos grandes." },
                { "spearow", "Tipo normal/volador. Habita en llanuras. Tiene pico puntiagudo." },
                { "fearow", "Tipo normal/volador. Habita en llanuras. Tiene alas largas." },
                { "ekans", "Tipo veneno. Habita en praderas. Es una serpiente larga." },
                { "arbok", "Tipo veneno. Habita en selvas. Tiene patrón intimidante." },
                { "pikachu", "Tipo eléctrico. Habita en bosques. Tiene mejillas eléctricas." },
                { "raichu", "Tipo eléctrico. Habita en bosques. Tiene cola en forma de rayo." },
                { "sandshrew", "Tipo tierra. Habita en desiertos. Tiene cuerpo cubierto de placas." },
                { "sandslash", "Tipo tierra. Habita en desiertos. Tiene púas afiladas." },
                { "nidoran♀", "Tipo veneno. Habita en praderas. Tiene orejas grandes." },
                { "nidorina", "Tipo veneno. Habita en praderas. Tiene cuerpo robusto." },
                { "nidoqueen", "Tipo veneno/tierra. Habita en praderas. Tiene cuerpo fuerte y espinas." },
                { "nidoran♂", "Tipo veneno. Habita en praderas. Tiene cuerno pequeño." },
                { "nidorino", "Tipo veneno. Habita en praderas. Tiene cuerno más largo." },
                { "nidoking", "Tipo veneno/tierra. Habita en praderas. Tiene gran fuerza y cuerno duro." },
                { "clefairy", "Tipo hada. Habita en montañas. Tiene cuerpo rosado." },
                { "clefable", "Tipo hada. Habita en montañas. Tiene alas pequeñas." },
                { "vulpix", "Tipo fuego. Habita en montañas. Tiene seis colas." },
                { "ninetales", "Tipo fuego. Habita en montañas. Tiene nueve colas." },
                { "jigglypuff", "Tipo normal/hada. Habita en praderas. Tiene cuerpo redondo." },
                { "wigglytuff", "Tipo normal/hada. Habita en praderas. Tiene pelaje suave." },
                { "zubat", "Tipo veneno/volador. Habita en cuevas. No tiene ojos." },
                { "golbat", "Tipo veneno/volador. Habita en cuevas. Tiene boca grande." },
                { "oddish", "Tipo planta/veneno. Habita en bosques. Tiene hojas en la cabeza." },
                { "gloom", "Tipo planta/veneno. Habita en bosques. Tiene olor fuerte." },
                { "vileplume", "Tipo planta/veneno. Habita en selvas. Tiene flor grande." },
                { "paras", "Tipo bicho/planta. Habita en bosques. Tiene hongos en la espalda." },
                { "parasect", "Tipo bicho/planta. Habita en bosques. Tiene hongo dominante." },
                { "venonat", "Tipo bicho/veneno. Habita en bosques. Tiene ojos grandes." },
                { "venomoth", "Tipo bicho/veneno. Habita en bosques. Tiene alas polvorientas." },
                { "diglett", "Tipo tierra. Habita bajo tierra. Solo muestra la cabeza." },
                { "dugtrio", "Tipo tierra. Habita bajo tierra. Son tres unidos." },
                { "meowth", "Tipo normal. Habita en ciudades. Tiene moneda en la frente." },
                { "persian", "Tipo normal. Habita en ciudades. Tiene cuerpo elegante." },
                { "psyduck", "Tipo agua. Habita en ríos. Tiene dolores de cabeza." },
                { "golduck", "Tipo agua. Habita en lagos. Tiene gran habilidad natatoria." },
                { "mankey", "Tipo lucha. Habita en montañas. Tiene temperamento agresivo." },
                { "primeape", "Tipo lucha. Habita en montañas. Siempre está furioso." },
                { "growlithe", "Tipo fuego. Habita en praderas. Tiene pelaje rayado." },
                { "arcanine", "Tipo fuego. Habita en montañas. Tiene gran tamaño y velocidad." },
                { "poliwag", "Tipo agua. Habita en ríos. Tiene espiral en el vientre." },
                { "poliwhirl", "Tipo agua. Habita en lagos. Tiene brazos pequeños." },
                { "poliwrath", "Tipo agua/lucha. Habita en ríos. Tiene músculos fuertes." },
                { "abra", "Tipo psíquico. Habita en ciudades. Se teletransporta." },
                { "kadabra", "Tipo psíquico. Habita en ciudades. Tiene cucharas." },
                { "alakazam", "Tipo psíquico. Habita en ciudades. Tiene gran inteligencia." },
                { "machop", "Tipo lucha. Habita en montañas. Tiene cuerpo musculoso." },
                { "machoke", "Tipo lucha. Habita en montañas. Tiene cinturón limitador." },
                { "machamp", "Tipo lucha. Habita en montañas. Tiene cuatro brazos." },
                { "bellsprout", "Tipo planta/veneno. Habita en bosques. Tiene boca grande." },
                { "weepinbell", "Tipo planta/veneno. Habita en bosques. Tiene cuerpo colgante." },
                { "victreebel", "Tipo planta/veneno. Habita en selvas. Tiene boca amplia." },
                { "tentacool", "Tipo agua/veneno. Habita en mares. Tiene tentáculos." },
                { "tentacruel", "Tipo agua/veneno. Habita en mares. Tiene muchos tentáculos." },
                { "geodude", "Tipo roca/tierra. Habita en montañas. Tiene brazos fuertes." },
                { "graveler", "Tipo roca/tierra. Habita en montañas. Tiene cuerpo rocoso." },
                { "golem", "Tipo roca/tierra. Habita en montañas. Tiene caparazón duro." },
                { "ponyta", "Tipo fuego. Habita en praderas. Tiene crin en llamas." },
                { "rapidash", "Tipo fuego. Habita en praderas. Tiene gran velocidad." },
                { "slowpoke", "Tipo agua/psíquico. Habita en ríos. Es lento." },
                { "slowbro", "Tipo agua/psíquico. Habita en costas. Tiene shellder en cola." },
                { "magnemite", "Tipo eléctrico/acero. Habita en fábricas. Tiene imanes." },
                { "magneton", "Tipo eléctrico/acero. Habita en fábricas. Son tres unidos." },
                { "farfetch’d", "Tipo normal/volador. Habita en praderas. Lleva un puerro." },
                { "doduo", "Tipo normal/volador. Habita en praderas. Tiene dos cabezas." },
                { "dodrio", "Tipo normal/volador. Habita en praderas. Tiene tres cabezas." },
                { "seel", "Tipo agua. Habita en mares fríos. Tiene cuerpo blanco." },
                { "dewgong", "Tipo agua/hielo. Habita en mares fríos. Tiene cuerpo elegante." },
                { "grimer", "Tipo veneno. Habita en ciudades. Es masa tóxica." },
                { "muk", "Tipo veneno. Habita en ciudades. Tiene cuerpo viscoso." },
                { "shellder", "Tipo agua. Habita en mares. Tiene concha dura." },
                { "cloyster", "Tipo agua/hielo. Habita en mares. Tiene concha con púas." },
                { "gastly", "Tipo fantasma/veneno. Habita en lugares oscuros. Es gas." },
                { "haunter", "Tipo fantasma/veneno. Habita en casas abandonadas. Tiene manos flotantes." },
                { "gengar", "Tipo fantasma/veneno. Habita en sombras. Tiene sonrisa siniestra." },
                { "onix", "Tipo roca/tierra. Habita en cuevas. Tiene cuerpo de roca." },
                { "drowzee", "Tipo psíquico. Habita en ciudades. Come sueños." },
                { "hypno", "Tipo psíquico. Habita en ciudades. Usa péndulo." },
                { "krabby", "Tipo agua. Habita en playas. Tiene pinzas grandes." },
                { "kingler", "Tipo agua. Habita en playas. Tiene pinza gigante." },
                { "voltorb", "Tipo eléctrico. Habita en plantas eléctricas. Parece pokebola." },
                { "electrode", "Tipo eléctrico. Habita en plantas eléctricas. Puede explotar." },
                { "exeggcute", "Tipo planta/psíquico. Habita en selvas. Son huevos." },
                { "exeggutor", "Tipo planta/psíquico. Habita en selvas. Tiene tres cabezas." },
                { "cubone", "Tipo tierra. Habita en montañas. Lleva cráneo." },
                { "marowak", "Tipo tierra. Habita en montañas. Usa hueso como arma." },
                { "hitmonlee", "Tipo lucha. Habita en dojos. Tiene piernas largas." },
                { "hitmonchan", "Tipo lucha. Habita en dojos. Tiene guantes." },
                { "lickitung", "Tipo normal. Habita en praderas. Tiene lengua larga." },
                { "koffing", "Tipo veneno. Habita en ciudades. Flota y emite gas." },
                { "weezing", "Tipo veneno. Habita en ciudades. Tiene dos cabezas." },
                { "rhyhorn", "Tipo tierra/roca. Habita en montañas. Tiene cuerno fuerte." },
                { "rhydon", "Tipo tierra/roca. Habita en montañas. Tiene armadura." },
                { "chansey", "Tipo normal. Habita en hospitales. Lleva huevo." },
                { "tangela", "Tipo planta. Habita en bosques. Tiene enredaderas." },
                { "kangaskhan", "Tipo normal. Habita en praderas. Lleva cría." },
                { "horsea", "Tipo agua. Habita en mares. Escupe tinta." },
                { "seadra", "Tipo agua. Habita en mares. Tiene espinas." },
                { "goldeen", "Tipo agua. Habita en ríos. Tiene aleta elegante." },
                { "seaking", "Tipo agua. Habita en ríos. Tiene cuerno." },
                { "staryu", "Tipo agua. Habita en mares. Tiene núcleo." },
                { "starmie", "Tipo agua/psíquico. Habita en mares. Tiene gema." },
                { "mr. mime", "Tipo psíquico/hada. Habita en ciudades. Imita paredes." },
                { "scyther", "Tipo bicho/volador. Habita en bosques. Tiene guadañas." },
                { "jynx", "Tipo hielo/psíquico. Habita en montañas. Tiene cabello largo." },
                { "electabuzz", "Tipo eléctrico. Habita en plantas eléctricas. Tiene rayas." },
                { "magmar", "Tipo fuego. Habita en volcanes. Tiene cuerpo ardiente." },
                { "pinsir", "Tipo bicho. Habita en bosques. Tiene cuernos fuertes." },
                { "tauros", "Tipo normal. Habita en praderas. Tiene tres colas." },
                { "magikarp", "Tipo agua. Habita en ríos. Es pez naranja." },
                { "gyarados", "Tipo agua/volador. Habita en mares. Tiene cuerpo serpentino." },
                { "lapras", "Tipo agua/hielo. Habita en mares. Tiene caparazón." },
                { "ditto", "Tipo normal. Habita en cualquier lugar. Puede transformarse." },
                { "eevee", "Tipo normal. Habita en bosques. Tiene ADN inestable." },
                { "vaporeon", "Tipo agua. Habita en mares. Tiene aletas." },
                { "jolteon", "Tipo eléctrico. Habita en praderas. Tiene pelaje puntiagudo." },
                { "flareon", "Tipo fuego. Habita en montañas. Tiene pelaje caliente." },
                { "porygon", "Tipo normal. Habita en entornos digitales. Tiene cuerpo geométrico." },
                { "omanyte", "Tipo roca/agua. Habita en mares. Tiene concha espiral." },
                { "omastar", "Tipo roca/agua. Habita en mares. Tiene tentáculos." },
                { "kabuto", "Tipo roca/agua. Habita en mares. Tiene caparazón duro." },
                { "kabutops", "Tipo roca/agua. Habita en mares. Tiene cuchillas." },
                { "aerodactyl", "Tipo roca/volador. Habita en montañas. Tiene alas grandes." },
                { "snorlax", "Tipo normal. Habita en montañas. Tiene cuerpo enorme." },
                { "articuno", "Tipo hielo/volador. Habita en montañas nevadas. Tiene alas heladas." },
                { "zapdos", "Tipo eléctrico/volador. Habita en tormentas. Tiene plumas eléctricas." },
                { "moltres", "Tipo fuego/volador. Habita en volcanes. Tiene alas en llamas." },
                { "dratini", "Tipo dragón. Habita en mares. Tiene cuerpo serpiente." },
                { "dragonair", "Tipo dragón. Habita en mares. Tiene cuerpo elegante." },
                { "dragonite", "Tipo dragón/volador. Habita en mares. Tiene alas grandes." },
                { "mewtwo", "Tipo psíquico. Habita en laboratorios. Tiene cuerpo creado genéticamente." },
                { "mew", "Tipo psíquico. Habita en lugares ocultos. Tiene cuerpo pequeño y rosa." }
            };

            string textoMinusculas = recibido.ToLower();
            string respuesta = "Pokémon no encontrado.";

            foreach (var p in pokemones) { // Debemos recorrer para buscar el pokemon
                if (textoMinusculas.Contains(p.Key)) { // Key es el nombre del pokemon, value es el dato asociado a esa key(Es la descripcion del pokemon) 
                    respuesta = p.Value;
                    break;
                }
            }

            AgregarMensaje(respuesta, false);
        }

        private void AgregarMensaje(string texto, bool esUsuario) {
            // Se crea una burbuja de chat (Esto lo hizo copilot jeje)
            Border burbuja = new Border();
            burbuja.CornerRadius = new CornerRadius(10);
            burbuja.Padding = new Thickness(10);
            burbuja.Margin = new Thickness(0, 5, 0, 5);
            burbuja.MaxWidth = 550;

            TextBlock bloqueTexto = new TextBlock();
            bloqueTexto.Text = texto;
            bloqueTexto.TextWrapping = TextWrapping.Wrap;
            bloqueTexto.FontSize = 14;

            if (esUsuario) { // Estilo del mensaje del entrenador 
                burbuja.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1565C0"));
                bloqueTexto.Foreground = Brushes.White;
                burbuja.HorizontalAlignment = HorizontalAlignment.Right;
            } else { // Estilo del mensaje del bot
                burbuja.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9ECEF"));
                bloqueTexto.Foreground = Brushes.Black;
                burbuja.HorizontalAlignment = HorizontalAlignment.Left;
            }

            burbuja.Child = bloqueTexto;
            MensajesChat.Children.Add(burbuja);

            ScrollChat.ScrollToBottom(); // Se scrollea de manera automatica
        }
    }
}