using System.Collections.Generic;
using Crosschat.Client.Seedwork;
using Crosschat.Client.Seedwork.Controls;
using Crosschat.Client.Views.Controls;
using Xamarin.Forms;

namespace Crosschat.Client.Views
{
	public class ChatPage : MvvmableContentPage
    {
		public ChatPage(ViewModelBase viewModel) : base(viewModel)
		{
			Title = "Chat";
			Icon = "chat.png";

			var messageList = new ChatListView();
			messageList.VerticalOptions = LayoutOptions.FillAndExpand;
			messageList.SetBinding(ChatListView.ItemsSourceProperty, new Binding("Events"));
			messageList.ItemTemplate = new DataTemplate(CreateMessageCell);

			var leftButton = new Button();
			leftButton.Text = " Option One ";
			leftButton.VerticalOptions = LayoutOptions.EndAndExpand;
			leftButton.SetBinding(Button.CommandProperty, new Binding("SendMessageCommand"));
			leftButton.BackgroundColor = Color.Green;
			leftButton.BorderColor = Color.Green;
			leftButton.TextColor = Color.White;

			var rightButton = new Button();
			rightButton.Text = " Option Two ";
			rightButton.VerticalOptions = LayoutOptions.EndAndExpand;
			rightButton.SetBinding(Button.CommandProperty, new Binding("SendMessageCommand"));
			rightButton.BackgroundColor = Color.Blue;
			rightButton.BorderColor = Color.Blue;
			rightButton.TextColor = Color.White;

			var optionButtons = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(0, Device.OnPlatform(0, 20, 0), 0, 0),
				HorizontalOptions = LayoutOptions.Center
			};
			optionButtons.Children.Add(leftButton);
			optionButtons.Children.Add(rightButton);

            Content = new StackLayout
                {
                    Padding = Device.OnPlatform(new Thickness(6,6,6,6), new Thickness(0), new Thickness(0)),
                    Children =
                        {
							messageList,
							optionButtons
                        }
                };
        }

        private Cell CreateMessageCell()
        {
            var timestampLabel = new Label();
            timestampLabel.SetBinding(Label.TextProperty, new Binding("Timestamp", stringFormat: "[{0:HH:mm}]"));
            timestampLabel.TextColor = Color.Silver;
            timestampLabel.Font = Font.SystemFontOfSize(14);

            var authorLabel = new Label();
            authorLabel.SetBinding(Label.TextProperty, new Binding("AuthorName", stringFormat: "{0}: "));
            authorLabel.TextColor = Device.OnPlatform(Color.Blue, Color.Yellow, Color.Yellow);
            authorLabel.Font = Font.SystemFontOfSize(14);

            var messageLabel = new Label();
            messageLabel.SetBinding(Label.TextProperty, new Binding("Text"));
            messageLabel.Font = Font.SystemFontOfSize(14);

            var stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {authorLabel, messageLabel}
                };

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                stack.Children.Insert(0, timestampLabel);
            }

            var view = new MessageViewCell
                {
                    View = stack
                };
            return view;
        }
    }
}
