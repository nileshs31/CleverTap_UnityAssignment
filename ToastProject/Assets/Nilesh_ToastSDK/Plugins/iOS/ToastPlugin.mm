#import <UIKit/UIKit.h>

extern "C"
{
    void ShowToast(const char *message)
    {
        if (message == NULL) return;

        NSString *msg = [NSString stringWithUTF8String:message];
        if (msg.length == 0) return;

        dispatch_async(dispatch_get_main_queue(), ^{
            UIWindow *window = UIApplication.sharedApplication.windows.firstObject;
            if (!window) return;

            UILabel *label = [[UILabel alloc] init];
            label.text = msg;
            label.textColor = UIColor.whiteColor;
            label.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.85];
            label.textAlignment = NSTextAlignmentCenter;
            label.numberOfLines = 0;
            label.layer.cornerRadius = 12;
            label.layer.masksToBounds = YES;

            CGFloat paddingX = 16;
            CGFloat paddingY = 12;

            CGSize maxSize = CGSizeMake(window.bounds.size.width - 40, CGFLOAT_MAX);
            CGSize textSize = [label sizeThatFits:maxSize];

            CGFloat width = textSize.width + paddingX * 2;
            CGFloat height = textSize.height + paddingY * 2;

            label.frame = CGRectMake(
                (window.bounds.size.width - width) / 2,
                window.bounds.size.height - height - 100,
                width,
                height
            );

            [window addSubview:label];

            label.alpha = 0.0;
            [UIView animateWithDuration:0.25 animations:^{
                label.alpha = 1.0;
            }];

            dispatch_after(dispatch_time(DISPATCH_TIME_NOW, 2 * NSEC_PER_SEC),
                           dispatch_get_main_queue(), ^{
                [UIView animateWithDuration:0.25 animations:^{
                    label.alpha = 0.0;
                } completion:^(BOOL finished) {
                    [label removeFromSuperview];
                }];
            });
        });
    }
}
