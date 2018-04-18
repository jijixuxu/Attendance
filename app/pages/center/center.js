var app = getApp()
Page({

  data: {
    userInfo: {},
    userid: ''
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this
    console.log('+' + wx.getStorageSync('userid')),
      console.log('+' + wx.getStorageSync('usertype'))

    if (wx.getStorageSync('userid') == '' || wx.getStorageSync('userid') == null) {
      wx.navigateTo({
        url: '../login/login'
      })
    }
    else {
      wx.getUserInfo({
        success: function (res) {
          that.setData({
            userInfo: res.userInfo,
            userid: wx.getStorageSync('userid')
          })
        }
      })
     
    }
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})