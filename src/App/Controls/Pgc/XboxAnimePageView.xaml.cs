﻿// Copyright (c) Richasy. All rights reserved.

using System;
using Bili.Models.Data.Community;
using Bili.ViewModels.Uwp.Base;
using Bili.ViewModels.Uwp.Core;
using Splat;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Bili.App.Controls.Pgc
{
    /// <summary>
    /// 适用于 Xbox 的动漫页视图.
    /// </summary>
    public sealed partial class XboxAnimePageView : UserControl
    {
        /// <summary>
        /// <see cref="ViewModel"/> 的依赖属性.
        /// </summary>
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(AnimePageViewModelBase), typeof(XboxAnimePageView), new PropertyMetadata(default, new PropertyChangedCallback(OnViewModelChanged)));

        /// <summary>
        /// Initializes a new instance of the <see cref="XboxAnimePageView"/> class.
        /// </summary>
        public XboxAnimePageView()
            => InitializeComponent();

        /// <summary>
        /// 视图模型.
        /// </summary>
        public AnimePageViewModelBase ViewModel
        {
            get { return (AnimePageViewModelBase)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        /// <summary>
        /// 核心视图模型.
        /// </summary>
        public AppViewModel CoreViewModel { get; } = Locator.Current.GetService<AppViewModel>();

        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as XboxAnimePageView;
            instance.DataContext = e.NewValue;
        }

        private void OnRootNavViewItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var data = args.InvokedItem as Partition;
            ContentScrollViewer.ChangeView(0, 0, 1);
            ViewModel.SelectPartitionCommand.Execute(data).Subscribe();
        }
    }
}
