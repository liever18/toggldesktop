//
//  Date+Utils.swift
//  TogglDesktop
//
//  Created by Nghia Tran on 4/19/19.
//  Copyright © 2019 Alari. All rights reserved.
//

import Foundation

extension Date {

    private static let daysOfWeek = [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"
    ]

    func dayOfWeekString() -> String? {
        guard let weekday = Calendar.current.dateComponents([.weekday], from: self).weekday else {
            return nil
        }
        return Date.daysOfWeek[safe: weekday - 1]
    }
}