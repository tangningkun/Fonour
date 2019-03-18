define(['main', 'lay!layer'], function(main) {
  var layer = layui.layer;
  var module = {
    _init: function(username, password) {
      if (_checkform(username, password)) {
        return;
      }
    },
    /**
     * 检查输入信息
     */
    _checkform: function() {
      if (isEmpty(username)) {
        layer.msg('用户名不能为空', { icon: 2 });
        return true;
      }
      if (isEmpty(password)) {
        layer.msg('密码不能为空', { icon: 2 });
        return true;
      }
      return false;
    },
    isEmpty(obj) {
      if (typeof obj == 'undefined' || obj == null || obj == '') {
        return true;
      } else {
        return false;
      }
    }
  };
  $('#btn-login').click(function() {
    debugger;
    let UserName = $('#form-username')
      .val()
      .trim();
    let PsssWord = $('#form-password')
      .val()
      .trim();
    module._init(UserName, PsssWord);
  });
});
