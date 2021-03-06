﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.UI;

namespace SubnauticMod.UI {
	public class UIProgressBarTextured : UIElement {
		public Color backgroundColor = Color.White;
		private Texture2D _backgroundTexture;
		private Texture2D _backgroundTexture2;
		private float width;
		private float defaultWidth;
		private float height;
		private int offsetX;
		private int offsetY;
		private bool alter = false;

		public UIProgressBarTextured(float height, float width, string texLoc, int texOffsetX = 0, int texOffsetY = 0) {
			_backgroundTexture = ModContent.GetTexture(texLoc);
			_backgroundTexture2 = ModContent.GetTexture(texLoc);
			this.height = height;
			this.width = width;
			offsetX = texOffsetX;
			offsetY = texOffsetY;
			defaultWidth = width;
		}

		public UIProgressBarTextured(float height, float width, string texLoc1, string texLoc2, int texOffsetX = 0, int texOffsetY = 0) {
			_backgroundTexture = ModContent.GetTexture(texLoc1);
			_backgroundTexture2 = ModContent.GetTexture(texLoc2);
			this.height = height;
			this.width = width;
			offsetX = texOffsetX;
			offsetY = texOffsetY;
			defaultWidth = width;
		}


		public override void OnInitialize() {
			Height.Set(height, 0f);
			Width.Set(width, 0f);
		}

		public void SetProgress(float progress) {
			Width.Set(defaultWidth * progress, 0f);
		}

		public void SetAlter(bool alter) {
			this.alter = alter;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) {
			Texture2D used = alter ? _backgroundTexture2 : _backgroundTexture;

			CalculatedStyle dimensions = GetDimensions();
			Point point1 = new Point((int) dimensions.X, (int) dimensions.Y);
			int width = (int) Math.Ceiling(dimensions.Width);
			int height = (int) Math.Ceiling(dimensions.Height);
			spriteBatch.Draw(used, new Rectangle(point1.X, point1.Y, width, height),
				new Rectangle(offsetX, offsetY, width, height), backgroundColor);
		}
	}
}
