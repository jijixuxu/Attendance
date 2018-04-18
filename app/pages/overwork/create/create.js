// pages/overwork/create/create.js
//获取应用实例
var app = getApp()
var util = require('../../../utils/util.js')
Page({
  data:{
    uindex: null,
    index: 0, // 默认显示第一条
    date: '2017-06-03',
    start: null,
    end: null,
    time: '01:30',
    UI: [
      { title: "新建", current: "当前选择", datepicker: "考勤日期", timepicker: "考勤时长", reasonpicker: "考勤类型", memo: "备注", save: "保存"},
      {title: "Create new record", current: "Current", datepicker: "Choose date", timepicker: "Choose overwork time", reasonpicker: "Reason", memo: "Memo",save: "Save"},
      {title: "新規", current: "選択項目", datepicker: "残業日", timepicker: "残業時間", reasonpicker: "残業理由", memo: "メモ", save: "保存"}
    ],
    overworkReasons: [
      [{id:"default", msg: "事假"}, {id: "customer", msg: "年假"}, {id: "projectDelay", msg: "病假"}],
      [{id:"default", msg: "No special reason"}, {id: "customer", msg: "Customer Situation"}, {id: "projectDelay", msg: "Project Delay"}],
      [{id:"default", msg: "理由なし"}, {id: "customer", msg: "お客様事情"}, {id: "projectDelay", msg: "納期遅れ"}],
    ]
    },
  onLoad:function(options){
    // 页面初始化 options为页面跳转所带来的参数
    var now = Date.now();
    var today = util.formatDate(new Date(now), "today");
    var start = util.formatDate(new Date(now), "start");
    var end = util.formatDate(new Date(now), "end");
    this.setData({
      date: today,
      start: start,
      end: end
    })
  },
  onReady:function(){
    // 页面渲染完成
  },
  onShow:function(){
    // 页面显示
    // 设置app语言的全局变量  
    var selectedLanguage = app.globalData.settings.language;
    var reason = ["无加班理由", "Reason of overwork", "理由なし"][selectedLanguage];
    console.log(reason);
    console.log('Current Language:' + selectedLanguage + ' (0: ZH-ch 1: ENG)');
    this.setData({
      uindex: selectedLanguage
    })
  },
  bindPickerChange: function(e) {
    console.log('picker发送选择改变，携带值为', e.detail.value)
    this.setData({
      index: e.detail.value
    })
  },
  bindDateChange: function(e) {
    this.setData({
      date: e.detail.value
    })
  },
  bindTimeChange: function(e) {
    this.setData({
      time: e.detail.value
    })
  },
  formSubmit: function (e) {
    var that = this;
    if (wx.getStorageSync('userid') == '' || wx.getStorageSync('userid') == null) {

      // 无账户绑定
      wx.showModal({
        title: '当前无绑定账户',
        content: '请登录账户后，再进行考勤打卡',
        cancelText: '返回',
        confirmText: '去登录',
        success: function (res) {
          if (res.confirm) {
            wx.navigateTo({
              url: '../../login/login'
            })
          } else {
            wx.navigateBack({ delta: 1 });
          }
        }
      })
    }
    else {
      wx.request({
        url: app.globalData.api, //接口地址
        data: {
          opt: 'Forleave',
          user: wx.getStorageSync('userid'),
          date: e.detail.value.date,
          reason: e.detail.value.reason,
          time: e.detail.value.time,
          memo: e.detail.value.memo
        },
        header: {
          'content-type': 'application/json'
        },
        success: function (res) {
          wx.navigateTo({
            url: '../../forleave/forleave'
          })
        }
      })
    }
  }
})