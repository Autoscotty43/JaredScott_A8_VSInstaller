using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FaceGenerator
{
    public partial class MainWindow : Window
    {
        private string basePath = "Sample_Faces";
        private int hairIndex = 1, eyesIndex = 1, noseIndex = 1, mouthIndex = 1;

        public MainWindow()
        {
            InitializeComponent();
            LoadBaseHead();
        }

        private void LoadBaseHead()
        {
            try
            {
                string baseHeadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, basePath, "base_head.png");
                if (File.Exists(baseHeadPath))
                {
                    Image baseHead = new Image
                    {
                        Source = new BitmapImage(new Uri(baseHeadPath, UriKind.Absolute)),
                        Width = 400,
                        Height = 400,
                        Stretch = System.Windows.Media.Stretch.Uniform
                    };

                    // Clear only base head, not the features
                    var oldBaseHead = FaceCanvas.Children
                        .OfType<Image>()
                        .FirstOrDefault(img => img.Tag?.ToString() == "BaseHead");

                    if (oldBaseHead != null)
                    {
                        FaceCanvas.Children.Remove(oldBaseHead);
                    }

                    baseHead.Tag = "BaseHead";
                    FaceCanvas.Children.Add(baseHead);
                    Panel.SetZIndex(baseHead, 0); // Base head at the back
                }
                else
                {
                    MessageBox.Show($"Base head image not found at {baseHeadPath}", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading base head: {ex.Message}", "Error");
            }
        }

        private void HairButton_Click(object sender, RoutedEventArgs e)
        {
            string folder = Path.Combine(basePath, "Hair");
            hairIndex = ChangeFeature(folder, "hair_", hairIndex);
            HairLabel.Text = $"Hair: {hairIndex}";
        }

        private void EyesButton_Click(object sender, RoutedEventArgs e)
        {
            string folder = Path.Combine(basePath, "Eyes");
            eyesIndex = ChangeFeature(folder, "eyes_", eyesIndex);
            EyesLabel.Text = $"Eyes: {eyesIndex}";
        }

        private void NoseButton_Click(object sender, RoutedEventArgs e)
        {
            string folder = Path.Combine(basePath, "Nose");
            noseIndex = ChangeFeature(folder, "nose_", noseIndex);
            NoseLabel.Text = $"Nose: {noseIndex}";
        }

        private void MouthButton_Click(object sender, RoutedEventArgs e)
        {
            string folder = Path.Combine(basePath, "Mouth");
            mouthIndex = ChangeFeature(folder, "mouth_", mouthIndex);
            MouthLabel.Text = $"Mouth: {mouthIndex}";
        }

        private int ChangeFeature(string folderPath, string prefix, int currentIndex)
        {
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderPath);
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Directory not found: {folderPath}", "Error");
                return currentIndex;
            }

            var files = Directory.GetFiles(folderPath, $"{prefix}*.png");
            if (files.Length == 0)
            {
                MessageBox.Show($"No images found for {prefix}", "Error");
                return currentIndex;
            }

            currentIndex++;
            if (currentIndex > files.Length) currentIndex = 1;

            string filePath = files[currentIndex - 1];
            Image featureImage = new Image
            {
                Source = new BitmapImage(new Uri(filePath, UriKind.Absolute)),
                Width = 400,
                Height = 125, // Adjust height proportionally
                Stretch = System.Windows.Media.Stretch.Uniform
            };

            // Remove old feature of the same type
            var oldFeature = FaceCanvas.Children
                                .OfType<Image>()
                                .FirstOrDefault(img => img.Tag?.ToString() == prefix);

            if (oldFeature != null)
            {
                FaceCanvas.Children.Remove(oldFeature);
            }

            featureImage.Tag = prefix;
            FaceCanvas.Children.Add(featureImage);

            // Set the correct layering and positioning based on feature type
            switch (prefix)
            {
                case "hair_":
                    Canvas.SetLeft(featureImage, -25);
                    Canvas.SetTop(featureImage, -10); // Move slightly up
                    Panel.SetZIndex(featureImage, 4); // Highest layer
                    break;
                case "eyes_":
                    Canvas.SetLeft(featureImage, 0); // Center horizontally
                    Canvas.SetTop(featureImage, 70);  // Eyes position
                    Panel.SetZIndex(featureImage, 3);
                    break;
                case "nose_":
                    Canvas.SetLeft(featureImage, 0); // Adjust horizontally
                    Canvas.SetTop(featureImage, 150);  // Nose position
                    Panel.SetZIndex(featureImage, 2);
                    break;
                case "mouth_":
                    Canvas.SetLeft(featureImage, 0); // Center mouth
                    Canvas.SetTop(featureImage, 220);  // Mouth position
                    Panel.SetZIndex(featureImage, 1);
                    break;
            }

            return currentIndex;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            hairIndex = eyesIndex = noseIndex = mouthIndex = 1;
            HairLabel.Text = "Hair: None";
            EyesLabel.Text = "Eyes: None";
            NoseLabel.Text = "Nose: None";
            MouthLabel.Text = "Mouth: None";
            LoadBaseHead();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Face Generator\nSelect hair, eyes, nose, and mouth to create a custom face.", "Info");
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the path of the executing assembly (exe location)
                string exePath = AppDomain.CurrentDomain.BaseDirectory;
                string helpFile = Path.Combine(exePath, "Help", "FaceMakerHelp.chm");

                if (File.Exists(helpFile))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = helpFile,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show($"Help file not found at: {helpFile}", "Help");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening help file: {ex.Message}", "Help");
            }
        }
    }
}