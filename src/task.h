// Copyright 2014 Toggl Desktop developers.

#ifndef SRC_TASK_H_
#define SRC_TASK_H_

#include <string>

#include <json/json.h>  // NOLINT

#include <Poco/Types.h>

#include "base_model.h"

namespace toggl {

class TOGGL_INTERNAL_EXPORT Task : public BaseModel {
    Task(ProtectedContainerBase *container)
        : BaseModel(container)
    , name_("")
    , wid_(0)
    , pid_(0)
    , active_(false) {}
 public:
    friend class ProtectedContainer<Task>;

    const std::string &Name() const {
        return name_;
    }
    void SetName(const std::string &value);

    const Poco::UInt64 &WID() const {
        return wid_;
    }
    void SetWID(const Poco::UInt64 value);

    const Poco::UInt64 &PID() const {
        return pid_;
    }
    void SetPID(const Poco::UInt64 value);

    const bool &Active() const {
        return active_;
    }
    void SetActive(const bool value);

    // Override BaseModel
    std::string String() const override;
    std::string ModelName() const override;
    std::string ModelURL() const override;
    void LoadFromJSON(Json::Value value) override;

 private:
    std::string name_;
    Poco::UInt64 wid_;
    Poco::UInt64 pid_;
    bool active_;
};

}  // namespace toggl

#endif  // SRC_TASK_H_
