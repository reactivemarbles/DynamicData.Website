---
Title: DynamicData brings the power of reactive (rx) to collections
_disableTocFilter: true
_layout: landing
---

<div class="container">
        <div class="row branding">
            <div class="span6 col-md-6">
                <div class="row">
                    <div class="col-md-4">
                      <img class="img-responsive branding-image" alt="DynamicData" src="images/logo.png" />
                    </div>
                    <div class="col-md-8">
                    	<h1 class="branding-title">DynamicData</h1>
                        <h3>
                        	Dynamic Data is a portable class library which brings the power of Reactive Extensions (Rx) to collections.
                    	</h3>
                        <a class="branding-button" href="~/docs/getting-started/index.md">
                            🛠️ Get Started
                        </a> &nbsp;
                        <a class="branding-button secondary-button" href="https://github.com/reactivemarbles/DynamicData">
                    		⭐ Star on GitHub
                        </a>
                    </div>
                </div>
            </div>
            <div class="span6 col-md-6 hidden-sm hidden-xs">
                <br class="visible-xs visible-sm">
                <div class="code-sample">
                 	<pre class="branding-code">
<a class="text-info" href="">ReadOnlyObservableCollection<TradeProxy> list;</a>
<a class="text-info" href=""></a>
<a class="text-info" href="">var myTradeCache = new SourceCache<Trade, long>(trade => trade.Id);</a>
<a class="text-info" href="">var myOperation = myTradeCache.Connect()</a>
    .<a class="text-info" href="">Filter(trade=>trade.Status == TradeStatus.Live)</a>   //filter on live trades only
    .<a class="text-info" href="">Transform(trade => new TradeProxy(trade))</a>         //create a proxy
    .<a class="text-info" href="">Sort(SortExpressionComparer<TradeProxy>.Descending(t => t.Timestamp))</a>
    .<a class="text-info" href="">ObserveOnDispatcher()</a>          //ensure operation is on the UI thread.
    .<a class="text-info" href="">Bind(out data)</a>                 //Populate the observable collection
    .<a class="text-info" href="">DisposeMany()</a>                  //Dispose TradeProxy when no longer required
    .<a class="text-info" href="">Subscribe();</a>
                  </pre>
                </div>
            </div>
        </div>
    </div>
<div class="container" style="margin-top: 30px">
    <div class="row text-center">
        <div class="span6 col-md-4">
            <h3 class="branding-subheader">The Example above</h3>
            <p>This collection is made observable by calling the Connect() method which produces an observable change set.</p>
            <p>First filters are applied to Filter a stream of trades to select only live trades, then creates a proxy for each live trade, and finally orders the results by most recent first. The resulting trade proxies are bound on the dispatcher thread to the specified observable collection.</p>
            <p>Since the TradeProxy object is disposable, the DisposeMany operator ensures that the proxy objects are disposed when they are no longer part of this observable stream.</p>
        </div>
        <div class="span6 col-md-4">
            <h3 class="branding-subheader">Composable</h3>
            <p>Create re-usable chunks of functionality that can be seamlessly integrated into your reactive pipelines. These chunks might be widely applicable, or specific to your application. Regardless, you have the power to write and <a href="docs/handbook/testing.md")">test code</a> once, and leverage it many times over.</p>
        </div>
        <div class="span6 col-md-4">
            <h3 class="branding-subheader">Cross-platform</h3>
            <p>Any device, any platform. Share business logic between your mobile and desktop applications. Dynamic Data has <a href="~/docs/getting-started/installation/index.md">first class support</a> for MAUI, Windows Presentation Foundation (WPF), Windows Forms, UNO Platform, Xamarin Forms, Xamarin.iOS, Xamarin.Android, Xamarin.Mac, &amp; Tizen.</p>
        </div>
    </div>
</div>
<div class="container" style="margin-top: 30px">
    <div class="row text-center">
        <div class="span6 col-md-4">
            <h3 class="branding-subheader">Open-source</h3>
            <p>Dynamic Data is developed under an <a href="https://github.com/reactivemarbles/DynamicData/blob/main/LICENSE" target="_blank">OSI-approved open source license</a>, making it freely usable and distributable, even for commercial use. We ❤ the people who are involved in this project, and we’d love <a href="~/Contribute/index.md">to have you on board</a>, especially if you are just getting started or have never contributed to open-source before.</p>
        </div>
    </div>
</div>
