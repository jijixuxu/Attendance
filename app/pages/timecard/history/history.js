// pages/timecard/history/history.js
var app = getApp()
const AV = require('../../../utils/av-weapp-min');
const Check = require('../../../model/check')

Page({
  data:{
    checks: null
  },
  onLoad:function(options){
    // 页面初始化 options为页面跳转所带来的参数  
    wx.showNavigationBarLoading();
  
    if (wx.getStorageSync('userid') == '' || wx.getStorageSync('userid') == null){
      wx.hideNavigationBarLoading()
      wx.showModal({
        title: '当前无绑定账户',
        content: '请绑定账户后，再查看考勤历史',        
        cancelText: '返回',
        confirmText: '去绑定',
        success: function(res){      
          if(res.confirm) {
            wx.navigateTo({
              url: '../../login/login'
            })
          } else {            
            wx.navigateBack({delta: 1});
          }
        }
      })      
    }
    else
    {
      var that = this
      wx.request({//banner图
        url: app.globalData.api, //接口地址
        data: {
          opt: 'AttendanceList',
          userid: wx.getStorageSync('userid') 
        },
        header: {
          'content-type': 'application/json'
        },
        success: function (res) {
          console.log(res.data)
          that.setData({
            checks: res.data
          })
        }
      });
    }
  },
  fetchChecks:function () {    
    return AV.Promise.resolve(AV.User.current()).then(user =>
    {
      console.log('uid', user.id);
      console.log(AV.Object.createWithoutData('User', user.id));
      wx.hideNavigationBarLoading()

      return new AV.Query(Check)
      .equalTo('user', AV.Object.createWithoutData('User', user.id))
      .descending('createdAt')
      .find().then(this.setChecks)  
    });
  },
  setChecks:function(checks){
    console.log(checks);
    this.setData({
      checks: checks.map(check => Object.assign(check.toJSON(), {
          timestamp: check.timestamp.toLocaleString(),
        }))
    })
  },
  toDetail: function(e){
    var check = e.currentTarget.dataset.check;
    var geo = check.geo;
    console.log('../maps/maps?latitude=' + geo.latitude + '&longitude=' + geo.longitude   )
    wx.openLocation({
      latitude: geo.latitude, // 纬度，范围为-90~90，负数表示南纬
      longitude: geo.longitude, // 经度，范围为-180~180，负数表示西经
      scale: 28, // 缩放比例
      name: check.location, // 位置名
      address: check.address, // 地址的详细说明    
    })
  },
  onShow:function(){
    this.fetchChecks();
  }
})