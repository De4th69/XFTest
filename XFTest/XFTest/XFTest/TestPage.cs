using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFTest
{
    public class TestPage : ContentPage
    {
        private StackLayout _mainStack, _stack, _stack1, _stack2, _stack3, _stack4, _stack5, _stack6, _stack7;

        private Grid _buttonGrid;

        private static Position position;

        private bool _close;

        public TestPage()
        {
            Title = "Test";

            var nextButton = new Button
            {
                Text = "Next"
            };

            var backButton = new Button
            {
                Text = "Back"
            };

            _buttonGrid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            _buttonGrid.Children.Add(backButton, 0 , 0);
            _buttonGrid.Children.Add(nextButton, 1, 0);
            nextButton.Clicked += NextButtonOnClicked;
            backButton.Clicked += BackButtonOnClicked;

            _mainStack = new StackLayout
            {
                BackgroundColor = Color.White
            };

            CreateStacks();

            _mainStack.Children.Add(_stack);
            _mainStack.Children.Add(_buttonGrid);
            position = Position.one;
            _close = true;

            var frame = new Frame
            {
                OutlineColor = Color.Red,
                HasShadow = true,
                Content = _mainStack
            };

            var rel = new RelativeLayout();
            rel.Children.Add(frame, Constraint.Constant(15), Constraint.Constant(15), Constraint.RelativeToParent((parent) => parent.Width - 30), Constraint.RelativeToParent((parent)=> parent.Height - 30));

            Content = rel;
        }

        protected override bool OnBackButtonPressed()
        {
            HandleBackNavigation();
            return _close;
        }

        private void BackButtonOnClicked(object sender, EventArgs eventArgs)
        {
            HandleBackNavigation();
        }

        private async void HandleBackNavigation()
        {
            switch (position)
            {
                case Position.one:
                    RemoveChildren();
                    _close = true;
                    break;
                case Position.two:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.one;
                    _close = true;
                    break;
                case Position.three:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack2);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.two;
                    _close = true;
                    break;
                case Position.four:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack3);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.three;
                    _close = true;
                    break;
                case Position.five:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack4);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.four;
                    _close = true;
                    break;
                case Position.six:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack5);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.five;
                    _close = true;
                    break;
                case Position.seven:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack6);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.six;
                    _close = true;
                    break;
            }
        }

        private async void NextButtonOnClicked(object sender, EventArgs eventArgs)
        {
            switch (position)
            {
                case Position.one:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack1);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.two;
                    break;
                case Position.two:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack3);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.three;
                    break;
                case Position.three:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack4);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.four;
                    break;
                case Position.four:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack5);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.five;
                    break;
                case Position.five:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack6);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.six;
                    break;
                case Position.six:
                    await _mainStack.ScaleTo(0.9, 80, Easing.CubicOut);
                    RemoveChildren();
                    _mainStack.Children.Add(_stack7);
                    _mainStack.Children.Add(_buttonGrid);
                    await _mainStack.ScaleTo(1, 80, Easing.CubicIn);
                    position = Position.seven;
                    break;
            }
        }

        private void RemoveChildren()
        {
            if (_mainStack.Children.Count == 2)
            {
                _mainStack.Children.RemoveAt(1);
                _mainStack.Children.RemoveAt(0);
            }
        }

        private void CreateStacks()
        {
            _stack = new StackLayout
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack1 = new StackLayout
            {
                BackgroundColor = Color.Green,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack2 = new StackLayout
            {
                BackgroundColor = Color.Lime,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack3 = new StackLayout
            {
                BackgroundColor = Color.Maroon,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack4 = new StackLayout
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack5 = new StackLayout
            {
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack6 = new StackLayout
            {
                BackgroundColor = Color.Teal,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _stack7 = new StackLayout
            {
                BackgroundColor = Color.Navy,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }


        private enum Position
        {
            one,
            two,
            three,
            four,
            five,
            six,
            seven
        }
    }
}
