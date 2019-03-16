define(['main'], function(main) {
  console.log('123');
  $('#login-form').bootstrapValidator({
    live: 'enabled', //验证时机，enabled是内容有变化就验证（默认），disabled和submitted是提交再验证
    excluded: [':disabled', ':hidden', ':not(:visible)'], //排除无需验证的控件，比如被禁用的或者被隐藏的
    submitButtons: '#btn-test', //指定提交按钮，如果验证失败则变成disabled，但我没试成功，反而加了这句话非submit按钮也会提交到action指定页面
    message: '通用的验证失败消息', //好像从来没出现过
    feedbackIcons: {
      //根据验证结果显示的各种图标
      valid: 'glyphicon glyphicon-ok',
      invalid: 'glyphicon glyphicon-remove',
      validating: 'glyphicon glyphicon-refresh'
    },
    fields: {
      Password: {
        validators: {
          notEmpty: {
            //检测非空
            message: '请输入密码'
          }
        }
      },
      UserName: {
        validators: {
          notEmpty: {
            //检测非空,radio也可用
            message: '请输入用户名'
          },
          stringLength: {
            //检测长度
            min: 3,
            max: 10,
            message: '长度必须在3-10之间'
          },
          regexp: {
            //正则验证
            regexp: /^[a-zA-Z0-9_\.]+$/,
            message: '所输入的字符不符要求'
          }
        }
      }
    }
  });

  $('#btn-login').click(function() {
    //非submit按钮点击后进行验证，如果是submit则无需此句直接验证
    $('#login-form').bootstrapValidator('validate'); //提交验证
    if (
      $('#login-form')
        .data('bootstrapValidator')
        .isValid()
    ) {
      //获取验证结果，如果成功，执行下面代码
      alert('yes'); //验证成功后的操作，如ajax
    }
  });
});
