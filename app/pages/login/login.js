// pages/login/login.js
var app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },
  //登录
  formSubmit: function (e) {
    var that = this;
    if (e.detail.value.userid.length == 0) {
      wx.showToast({
        title: '输入不得为空!',
        icon: 'loading',
        duration: 1500
      })
      setTimeout(function () {
        wx.hideToast()
      }, 2000)
    }
    else {
      wx.request({
        url: app.globalData.api, //接口地址
        data: {
          opt: 'Login',
          userid: e.detail.value.userid,
          userpwrd: e.detail.value.userpwrd
        },
        header: {
          'content-type': 'application/json'
        },
        success: function (res) {
          if (res.data.status == 0) {
            that.setData({
              userid: '',
              userpwrd: ''
            })
            
            wx.setStorageSync("userid", e.detail.value.userid),
              wx.setStorageSync("usertype", res.data.usertype),
              console.log('-' + res.data.status),
              console.log('-' + res.data.usertype),

            wx.navigateTo({
              url: '../index/index'
            })
          } else {
            wx.showToast({
              title: '登录失败',
              icon: 'loading',
              duration: 1500
            })
          }
        }
      })
    }
  }
})