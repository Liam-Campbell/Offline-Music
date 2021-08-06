using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;
using YoutubeExtractor;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder.Integration.AspNet.Core;

namespace LiamsMusic
{
	public partial class MainForm : MetroFramework.Forms.MetroForm
	{
		WMPLib.WindowsMediaPlayer Player=new WMPLib.WindowsMediaPlayer();
		List<Song> paths = new List<Song>();
		List<Song> pathsOrdered = new List<Song>();
		string CurrentSong = "";	
		public MainForm()
		{
			Player.settings.volume = LiamsMusic.Properties.Settings.Default.vol;
			InitializeComponent();
			Player.StatusChange +=SongEnded;
		}
		private void SongEnded()
		{
			if (Player.playState== WMPPlayState.wmppsMediaEnded)
			{
				Player = new WMPLib.WindowsMediaPlayer();
				Player.StatusChange += SongEnded;
				Player.settings.volume = LiamsMusic.Properties.Settings.Default.vol;
				GetRandomSong();
				PlaySong();
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			string[] fileEntries = Directory.GetFiles(LiamsMusic.Properties.Settings.Default.basePath);
			foreach (string fileName in fileEntries)
			{
				if (fileName.EndsWith(".mp3"))
				{
					if (fileName.Contains("-"))
					{
						paths.Add(new Song() { Songs= fileName.Split('/').Last().Split('-').Last().Split('.').First(),path=fileName});					
					}
					else
					{
						paths.Add(new Song() { Songs = fileName.Split('/').Last().Split('.').First(), path=fileName});
					}
				}
			}
			pathsOrdered = paths;
			slider.Value = LiamsMusic.Properties.Settings.Default.vol;
			ReloadGrid();
		}
		public void ReloadGrid()
		{
			dataGridView1.DataSource = pathsOrdered;
			dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns[1].Visible = false;
		}
		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (Player.playState == WMPPlayState.wmppsPaused|| Player.playState == WMPPlayState.wmppsUndefined)
			{				
				if (CurrentSong == "")
				{
					GetRandomSong();
					PlaySong();					
				}
				else
				{
					try
					{						
						Player.controls.play();
						btnPlay.Image = LiamsMusic.Properties.Resources.pause;
					}
					catch
					{
						MessageBox.Show("Couldn't play");
					}
				}
			}
			else if (Player.playState == WMPPlayState.wmppsPlaying)
			{				
				try
				{
					Player.controls.pause();
					btnPlay.Image = LiamsMusic.Properties.Resources.play1;
				}
				catch
				{
					MessageBox.Show("Couldn't pause");
				}
			}
			
		}
		private void GetRandomSong()
		{
			Random random = new Random();
			string temp = "";
			do
			{
				int i = random.Next(0, paths.Count);
				temp = paths[i].path;
			} while (temp== CurrentSong);
			CurrentSong = temp;
		}
		private void btnSettings_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fb = new FolderBrowserDialog();
			fb.ShowDialog();
			LiamsMusic.Properties.Settings.Default.basePath = fb.SelectedPath;
		}
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{		
			CurrentSong = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			PlaySong();
		}
		private void PlaySong()
		{
			if (Player.playState != WMPLib.WMPPlayState.wmppsUndefined)
			{
				Player.close();
			}
			Player.URL = CurrentSong;		
			Player.controls.play();
			btnPlay.Image = LiamsMusic.Properties.Resources.pause;
		}
		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			if (tbSearch.TextLength>0)
			{
				pathsOrdered = paths.Where(x => x.Songs.ToUpper().Contains(tbSearch.Text.ToUpper())).ToList();
			}
			else
			{
				pathsOrdered = paths;
			}
			ReloadGrid();
		}
		private void btnSkip_Click(object sender, EventArgs e)
		{
			GetRandomSong();
			PlaySong();
		}
		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
		}
		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon1.Visible = true;
			}
		}
		private void slider_ValueChanged(object sender, EventArgs e)
		{
			Player.settings.volume=slider.Value;
			LiamsMusic.Properties.Settings.Default.vol=slider.Value;
		}
		private void btnGetMore_Click(object sender, EventArgs e)
		{
			//DownloadVideo("https://www.youtube.com/watch?v=2ZIpFytCSVc");
			DownloadVideo("https://www.youtube.com/watch?v=9CBPnduL9LQ");
		}
		private async void DownloadVideo(string url)
		{
			IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);
			VideoInfo video = videoInfos.Where(info => info.CanExtractAudio).OrderByDescending(info => info.AudioBitrate).First();
			if (video.RequiresDecryption)
			{
				DownloadUrlResolver.DecryptDownloadUrl(video);
			}
			var audioDownloader = new AudioDownloader(video, Path.Combine(LiamsMusic.Properties.Settings.Default.basePath, video.Title + video.AudioExtension));
			audioDownloader.Execute();
		}
		public static IEnumerable<VideoInfo> GetDownloadUrls(string videoUrl, bool decryptSignature = true)
		{
			var json = LoadJson(videoUrl);
			string videoTitle = GetVideoTitle(json);
			IEnumerable<ExtractionInfo> downloadUrls = ExtractDownloadUrls(json);
			IEnumerable<VideoInfo> infos = GetVideoInfos(downloadUrls, videoTitle).ToList();
			string htmlPlayerVersion = GetHtml5PlayerVersion(json);
			foreach (VideoInfo info in infos)
			{
				info.HtmlPlayerVersion = htmlPlayerVersion;
				if (decryptSignature && info.RequiresDecryption)
				{
					DecryptDownloadUrl(info);
				}
			}
			return infos;
		}	
	}
	public class Song
	{
		public string Songs { get; set; }
		public string path { get; set; }
	}
}
