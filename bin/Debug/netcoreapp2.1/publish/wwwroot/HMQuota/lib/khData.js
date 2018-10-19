$(function () {

    var itemIndex = 0;

    var tabLoadEndArray = [false, false, false];
    var tabLenghtArray = [28, 15, 47];
    var tabScroolTopArray = [0, 0, 0];
    
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
            setTimeout(function () {
                if (tabLoadEndArray[itemIndex]) {
                    me.resetload();
                    me.lock();
                    me.noData();
                    me.resetload();
                    return;
                }
                var result = '';
                for (var index = 0; index < 10; index++) {
                    if (tabLenghtArray[itemIndex] > 0) {
                        tabLenghtArray[itemIndex]--;
                    } else {
                        tabLoadEndArray[itemIndex] = true;
                        break;
                    }
                    if (itemIndex == 0) {
                        result
                        += ''
                        + '    <hgroup class="khfxRow">'
                        + '      <header> 客户指标</header>'
                        + '      <div class="mid">'
                        + '        <img class="photo" src="images/img01.png" >'
                        + '        <span><label>名称：</label>星级客户</span> '
                        + '        <span><label>日期：</label>2018年9月28日11:01:04</span> '
                        + '      </div>'
                        + '      <footer><a href="#">查看详情</a></footer>'
                        + '    </hgroup>';
                    } else if (itemIndex == 1) {
                        result
                        += ''
                        + '    <hgroup class="khfxRow">'
                        + '      <header>业绩指标</header>'
                        + '      <div class="mid">'
                        + '        <img class="photo" src="images/img01.png" >'
                        + '        <span><label>名称：</label>科室预收</span> '
                        + '        <span><label>定义：</label>' + tabLenghtArray[itemIndex] + '</span> '
                        + '        <span><label>公式：</label>E=MC²</span> '
                        + '        <span><label>日期：</label>2018年9月28日11:01:04</span> '
                        + '      </div>'
                        + '      <footer><a href="#">查看详情</a></footer>'
                        + '    </hgroup>';
                    } else if (itemIndex == 2) {
                        result
                        += ''
                        + '<hgroup class="khfxRow">'
                        + '<header>员工指标</header>'
                        + '<div class="mid">'
                        + '        <img class="photo" src="images/img01.png" >'
                        + '        <span><label>名称：</label>新客业绩</span> '
                        + '        <span><label>定义：</label>' + tabLenghtArray[itemIndex] + '</span> '
                        + '        <span><label>公式：</label>E=MC²</span> '
                        + '        <span><label>日期：</label>2018年9月28日11:01:04</span> '
                        + '      </div>'
                        + '      <footer><a href="#">查看详情</a></footer>'
                        + '</hgroup>';
                    }
                }
                $('.khfxPane').eq(itemIndex).append(result);
                me.resetload();
            }, 500);
        }
    });


    $('.tabHead span').on('click', function () {

        tabScroolTopArray[itemIndex] = $(window).scrollTop();
        var $this = $(this);
        itemIndex = $this.index();
        $(window).scrollTop(tabScroolTopArray[itemIndex]);
        
        $(this).addClass('active').siblings('.tabHead span').removeClass('active');
        $('.tabHead .border').css('left', $(this).offset().left + 'px');
        $('.khfxPane').eq(itemIndex).show().siblings('.khfxPane').hide();

        if (!tabLoadEndArray[itemIndex]) {
            dropload.unlock();
            dropload.noData(false);
        } else {
            dropload.lock('down');
            dropload.noData();
        }
        dropload.resetload();
    });
});