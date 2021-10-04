function InitS2(ddls) {
    for (let index = 0; index < ddls.length; ++index) {
        $(ddls[index]).select2();
    };
}