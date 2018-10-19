$(function () {
    var itemIndex = 0;
    var tab1LoadEnd = false;
    var tab2LoadEnd = false;
    var pageIndex1 = 0, pageIndex2 = 0;
    // tab
    $('.tabHead span').on('click', function () {
        var $this = $(this);
        itemIndex = $this.index();
        $(this).addClass('active').siblings('.tabHead span').removeClass('active');
        $('.tabHead .border').css('left', $(this).offset().left + 'px');
        $('.khfxPane').eq(itemIndex).show().siblings('.khfxPane').hide();
        // 如果选中菜单一
        if (itemIndex == '0') {
            pageIndex1 = 0;
            // 如果数据没有加载完
            if (!tab1LoadEnd) {
                // 解锁
                dropload.unlock();
                dropload.noData(false);
            } else {
                // 锁定
                dropload.lock('down');
                dropload.noData();
            }
            // 如果选中菜单二
        } else if (itemIndex == '1') {
            pageIndex2 = 0;
            if (!tab2LoadEnd) {
                // 解锁
                dropload.unlock();
                dropload.noData(false);
            } else {
                // 锁定
                dropload.lock('down');
                dropload.noData();
            }
        }
        // 重置
        dropload.resetload();
    });




    // dropload
    var dropload = $('.khfxWarp').dropload({
        scrollArea: window,
        domDown: {
            domClass: 'dropload-down',
            domRefresh: '<div class="dropload-refresh">上拉加载更多</div>',
            domLoad: '<div class="dropload-load"><span class="loading"></span>加载中...</div>',
            domNoData: '<div class="dropload-noData">已无数据</div>'
        },
        loadDownFn: function (me) {
            pageIndex1++;
            // 加载菜单一的数据
            if (itemIndex == '0') {
                $.ajax({
                    type: 'GET',
                    url: 'http://localhost:5000/api/HMQuota/GetList/',
                    data: { "pageIndex": pageIndex1, "category": 1 },
                    dataType: 'json',
                    success: function (data) {
                        var result = '';
                       
                        if (1 <= data.items.length) {
                            for (var i = 0; i <= data.items.length - 1; i++) {

                                result +=
                                      '    <hgroup class="khfxRow">'
                                    + '      <header>业绩指标</header>'
                                    + '      <div class="mid">'
                                    + '        <span><label>名称：</label>' + data.items[i].quotaName + '</span> '
                                    + '        <span><label>日期：</label>' + data.items[i].createDate + '</span> '
                                    + '      </div>'
                                    + '      <footer><a href="javascript:detail('+ data.items[i].id+');\">查看详情</a></footer>'
                                    + '    </hgroup>';
                                    

                            }
                            if (pageIndex1 >= data.totalPages) {
                                // 数据加载完
                                tab1LoadEnd = true;
                                // 锁定
                                me.lock();
                                // 无数据
                                me.noData();
                                
                            }else if (0==data.items.length){
                                // 数据加载完
                                tab1LoadEnd = true;
                                // 锁定
                                me.lock();
                                // 无数据
                                me.noData();
                            }
                            $('.khfxPane').eq(itemIndex).append(result);
                            // 每次数据加载完，必须重置
                            me.resetload();

                        }
                    },
                    error: function (xhr, type) {
                        // 即使加载出错，也得重置
                        me.resetload();
                    }
                });
                // 加载菜单二的数据
            } else if (itemIndex == '1') {
                pageIndex2++;
                $.ajax({
                    type: 'GET',
                    url: 'http://localhost:5000/api/HMQuota/GetList/',
                    data: { "pageIndex": pageIndex2, "category": 2 },
                    dataType: 'json',
                    success: function (data) {
                        var result = '';
                       
                        if (1 <= data.items.length) {
                            for (var i = 0; i <= data.items.length - 1; i++) {

                                result +=
                                    '    <hgroup class="khfxRow">'
                                    + '      <header>业绩指标</header>'
                                    + '      <div class="mid">'
                                    + '        <span><label>名称：</label>' + data.items[i].quotaName + '</span> '
                                    + '        <span><label>日期：</label>' + data.items[i].createDate + '</span> '
                                    + '      </div>'
                                    + '      <footer><a href="javascript:detail('+ data.items[i].id+');\">查看详情</a></footer>'
                                    + '    </hgroup>';

                            }
                            if (pageIndex2  >= data.totalPages) {
                                // 数据加载完
                                tab2LoadEnd = true;
                                // 锁定
                                me.lock();
                                // 无数据
                                me.noData();
                                
                            }else if(0==data.items.length){
                                 // 数据加载完
                                 tab2LoadEnd = true;
                                 // 锁定
                                 me.lock();
                                 // 无数据
                                 me.noData();
                            }
                           
                            $('.khfxPane').eq(itemIndex).append(result);
                            // 每次数据加载完，必须重置
                            me.resetload();

                        }
                    },
                    error: function (xhr, type) {
                        // 即使加载出错，也得重置
                        me.resetload();
                    }
                });
            }
        }
    });
});


function detail(id){
    window.location.href="http://localhost:5000/HMQuota/index.1.html?headerId="+id;
}